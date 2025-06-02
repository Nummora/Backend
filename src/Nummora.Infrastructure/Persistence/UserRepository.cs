using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Contracts.Enums;
using Nummora.Domain;
using Nummora.Domain.Entities;
using Nummora.Domain.Exceptions;
using Nummora.Infrastructure.Data;

namespace Nummora.Infrastructure.Persistence;

public class UserRepository
    (ApplicationDbContext _context, 
        IMapper _mapper
    ) : IUserRepository
{
    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.AsNoTracking()
            .Include(u => u.UserWallets)
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role).ToListAsync();
    }

    public async Task<User> GetUserById(Guid id)
    {
        var result =  await _context.Users.AsNoTracking()
            .Include(u => u.UserDocuments)
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .Include(u => u.UserWallets)
            .FirstOrDefaultAsync(x => x.Id == id);
        return result!;
    }
    
    
    private Guid GetRoleIdFromEnum(UserRoleType roleEnum)
    {
        var roleEntity = _context.Roles.FirstOrDefault(r => r.Name == (Role.RoleUser)roleEnum);
        return roleEntity?.Id ?? throw new Exception("Rol not found");
    }
    public async Task<object> CreateUser(UserRegisterDto user)
    {
        var users = _mapper.Map<User>(user);

        users.UserRoles = new List<UserRole>
        {
            new UserRole
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse(user.Id),
                RoleId = GetRoleIdFromEnum(user.Role),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            }
        };
        
        _context.Users.Add(users);
        await _context.SaveChangesAsync();
        return users;
    }

    public async Task<User> UpdateUser(UserRegisterDto userRegisterDto)
    {
        var existUser = await _context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userRegisterDto.Id);

        if (existUser == null)
            throw new Exceptions.IdNotFoundException("User not found");

        _mapper.Map(userRegisterDto, existUser);
        await _context.SaveChangesAsync();
        return existUser;
    }

    public async Task<User> DeleteUser(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> Login(UserDto loginDto)
    {
        return await _context.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Email == loginDto.Email);
    }

    public async Task<User> UploadPhoto(Guid userId, string photoUrl)
    {
        var searchUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if(searchUser == null)
            throw new Exceptions.IdNotFoundException("User not found");

        searchUser.Photo = photoUrl;
        await _context.SaveChangesAsync();
        return searchUser;
    }

    public async Task<object> UploadPhotoOfDocument(Guid userId, string frontPhotoUrl, string backPhotoUrl)
    {
        var existsUser = await _context.Users
            .Include(u => u.UserDocuments).FirstOrDefaultAsync(u => u.Id == userId);
        
        if(existsUser == null)
            throw new Exceptions.IdNotFoundException("User not found");

        var userDocument = new UserDocument
        {
            FrontDocumentUrl = frontPhotoUrl,
            BackDocumentUrl = backPhotoUrl,
            UserId = userId,
        };
        
        existsUser.UserDocuments.Add(userDocument);
        
        await _context.SaveChangesAsync();
        return existsUser;
    }
}