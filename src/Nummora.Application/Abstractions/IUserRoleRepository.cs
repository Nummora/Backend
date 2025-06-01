using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IUserRoleRepository
{
    Task<UserRole> CreateUserRole(UserRole userRole);
}