using Microsoft.AspNetCore.Http;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IUserRepository
{
    Task<List<User>> GetUsers();
    Task<User> GetUserById(Guid id);
    Task<User> CreateUser(UserRegisterDto userRegisterDto);
    Task<User> UpdateUser(UserRegisterDto userRegisterDto);
    Task<User> DeleteUser(Guid id);
    Task<User> Login(UserDto loginDto);
    Task<User> UploadPhoto(Guid userId, string photoUrl);
}