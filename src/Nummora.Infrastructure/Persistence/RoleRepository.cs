using Microsoft.EntityFrameworkCore;
using Nummora.Application.Abstractions;
using Nummora.Domain.Entities;
using Nummora.Infrastructure.Data;

namespace Nummora.Infrastructure.Persistence;

public class RoleRepository(ApplicationDbContext _context) : IRoleRepository
{
    public async Task<Role> CreateAsync(Role role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return role;
    }

    public async Task<bool> ExistsByNameAsync(Role.RoleUser name)
    {
        return await _context.Roles.AnyAsync(r => r.Name == name);
    }
}