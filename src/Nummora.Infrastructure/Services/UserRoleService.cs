using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;
using Nummora.Domain.Exceptions;

namespace Nummora.Infrastructure.Services;

public class UserRoleService(IUserRoleRepository _userRoleRepository) : IUserRolService
{
    public async Task<Result<UserRole>> CreateUserRoleAsync(UserRoleDto userRoleDto)
    {
        try
        {
            var roles = new UserRole
            {
                UserId = userRoleDto.UserId,
                RoleId = userRoleDto.RoleId,
                CreateAt = DateTime.UtcNow
            };
            
            
            var role = await _userRoleRepository.CreateUserRole(roles);
            return Result<UserRole>.Success(role, "User Role Created");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occured while creating the user role: {e.InnerException?.Message ?? e.Message}");
        }
    }
}