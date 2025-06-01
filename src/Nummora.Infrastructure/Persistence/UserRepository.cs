using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
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
            .Include(u => u.UserWallets).ToListAsync();
    }

    public async Task<User> GetUserById(Guid id)
    {
        var result =  await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return result!;
    }

    public async Task<User> CreateUser(UserRegisterDto userRegisterDto)
    {
        var mapper = _mapper.Map<User>(userRegisterDto); 
        await _context.Users.AddAsync(mapper);
        await _context.SaveChangesAsync();
        return mapper;
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
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
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
}