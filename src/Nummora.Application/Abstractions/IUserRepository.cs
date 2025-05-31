using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IUserRepository
{
    Task<List<User>> GetUsers();
    Task<User> GetUserById(Guid id);
    Task<User> CreateUser(UserRegisterDto userRegisterDto);
    Task UpdateUser(User user);
    Task DeleteUser(Guid id);
}