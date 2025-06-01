using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;
using Nummora.Infrastructure.Data;

namespace Nummora.Infrastructure.Persistence;

public class UserRoleRepository(ApplicationDbContext _context) : IUserRoleRepository
{
    public async Task<UserRole> CreateUserRole(UserRole userRole)
    {
        var role = await _context.UserRoles.AddAsync(userRole);
        await _context.SaveChangesAsync();
        return role.Entity;
    }
}