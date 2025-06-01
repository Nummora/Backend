using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IUserRepository
{
    Task<List<User>> GetUsers();
    Task<User> GetUserById(Guid id);
    Task<object> CreateUser(UserRegisterDto user);
    Task<User> UpdateUser(UserRegisterDto userRegisterDto);
    Task<User> DeleteUser(Guid id);
    Task<User> Login(UserDto loginDto);
    Task<User> UploadPhoto(Guid userId, string photoUrl);
    Task<object> UploadPhotoOfDocument(Guid userId, string frontPhotoUrl, string backPhotoUrl);
}