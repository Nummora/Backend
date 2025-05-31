using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IUserService
{
    Task<Result<List<User>>> GetUsersAsync();
    Task<Result<User>> GetUserByIdAsync(Guid id);
    Task<Result<User>> CreateUserAsync(UserRegisterDto userRegisterDto);
    Task<Result<User>> UpdateUserAsync(User user);
}