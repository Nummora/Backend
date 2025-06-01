using Nummora.Application.Abstractions;
using Nummora.Domain;
using Nummora.Domain.Entities;
using Nummora.Domain.Exceptions;

namespace Nummora.Infrastructure.Services;

public class RoleService(IRoleRepository _roleRepository) : IRoleService
{
    public async Task<Result<Role>> CreateRoleAsync(RoleCreateDto dto)
    {
        try
        {
            if (await _roleRepository.ExistsByNameAsync(dto.Name))
            {
                throw new InvalidOperationException("Role already exists");
            }
            var newRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                CreateAt = DateTime.UtcNow
            };

            await _roleRepository.CreateAsync(newRole);
            return Result<Role>.Success(newRole, "Role created successfully");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred while creating the role: {e.InnerException?.Message ?? e.Message}");
        }
    }
}