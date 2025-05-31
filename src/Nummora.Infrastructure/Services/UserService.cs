using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Infrastructure.Services;

public class UserService : IUserService
{
    public Task<Result<List<User>>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<Result<User>> GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<User>> CreateUser(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<User>> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<Result<User>> DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }
}