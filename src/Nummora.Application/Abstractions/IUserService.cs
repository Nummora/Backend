using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IUserService
{
    Task<Result<List<User>>> GetUsers();
    Task<Result<User>> GetUserById(Guid id);
    Task<Result<User>> CreateUser(UserDto userDto);
    Task<Result<User>> UpdateUser(User user);
    Task<Result<User>> DeleteUser(Guid id);
}