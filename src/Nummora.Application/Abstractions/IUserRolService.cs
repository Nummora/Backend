using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IUserRolService
{
    Task<Result<UserRole>> CreateUserRoleAsync(UserRoleDto userRoleDto);
}