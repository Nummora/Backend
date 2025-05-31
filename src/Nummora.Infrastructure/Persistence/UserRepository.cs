using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;
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

    public Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> Login(UserDto loginDto)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
    }
}