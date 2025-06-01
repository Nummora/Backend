using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IRoleRepository
{
    Task<Role> CreateAsync(Role role);
    Task<bool> ExistsByNameAsync(Role.RoleUser name);
}