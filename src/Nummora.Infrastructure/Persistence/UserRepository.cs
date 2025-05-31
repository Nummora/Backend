using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    public Task<List<User>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User> CreateUser(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }
}