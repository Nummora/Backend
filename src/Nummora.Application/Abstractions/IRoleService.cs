using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IRoleService
{
    Task<Result<Role>> CreateRoleAsync(RoleCreateDto dto);
}