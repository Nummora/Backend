using Microsoft.AspNetCore.Http;
using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IUserService
{
    Task<Result<List<User>>> GetUsersAsync();
    Task<Result<User>> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<object>> CreateUserAsync(UserRegisterDto user, CancellationToken cancellationToken);
    Task<Result<User>> DeleteUserAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<User>> UpdateUserAsync(UserRegisterDto userRegisterDto, CancellationToken cancellationToken);
    Task<Result<User>> LoginAsync(UserDto loginDto, CancellationToken cancellationToken);
    Task<Result<string>> UploadPhotoAsync(Guid userId, IFormFile file, CancellationToken cancellationToken);
    Task<Result<List<string>>> UploadPhotoOfDocument(Guid userId, List<IFormFile> file, CancellationToken cancellationToken);
}