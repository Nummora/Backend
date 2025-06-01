using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Nummora.Application.Abstractions;
using Nummora.Application.Validators;
using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;
using Nummora.Domain.Exceptions;

namespace Nummora.Infrastructure.Services;

public class UserService(IUserRepository _userRepository, UserValidator userValidator, Cloudinary cloudinary) : IUserService
{
    public async Task<Result<List<User>>> GetUsersAsync()
    {
        try
        {
            var users = await _userRepository.GetUsers();
            return Result<List<User>>.Success(users, "Users found");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred getting user {e.Message}");
        }
    }

    public async Task<Result<User>> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userRepository.GetUserById(id);
            return Result<User>.Success(user,"User found");
        }
        catch (KeyNotFoundException e)
        {
            throw new Exceptions.IdNotFoundException($"Has been impossible to get user {e.Message}");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred getting user {e.Message}");
        }
    }

    public async Task<Result<object>> CreateUserAsync(UserRegisterDto user, CancellationToken cancellationToken = default)
    {
        try
        {
            var validate = userValidator.Validate(user);
            if(!validate.IsValid)
                return Result<object>.Failure(validate.Errors.ToString()??"It is not possible to create a user");

            
            var newUser = await _userRepository.CreateUser(user);
            return Result<object>.Success(newUser, "User Created");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred creating user {e.InnerException?.Message ?? e.Message}");
        }
    }

    public async Task<Result<User>> DeleteUserAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.DeleteUser(id);
        return user == null ? Result<User>.Failure("User not found") : Result<User>.Success(user, "User deleted"); 
    }

    public async Task<Result<User>> UpdateUserAsync(UserRegisterDto userRegisterDto, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.UpdateUser(userRegisterDto);
        return Result<User>.Success(user, "User updated");
    }

    public async Task<Result<User>> LoginAsync(UserDto loginDto, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _userRepository.Login(loginDto);
            Console.WriteLine($"logging attempt for user {user.Email}");

            if (user == null)
            {
                return Result<User>.Failure("User not found");
            }
            
            if (user.Password != loginDto.Password)
            {
                return Result<User>.Failure("Invalid credentials");
            }
            return Result<User>.Success(user, "User logged in");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred logging in {e.InnerException?.Message ?? e.Message}");
        }
    }

    public async Task<Result<string>> UploadPhotoAsync(Guid userId, IFormFile file, CancellationToken cancellationToken)
    {
        try
        {
            if (file == null || file.Length == 0)
                throw new ArgumentNullException(nameof(file));


            ImageUploadResult uploadResult;
            await using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = $"/users/{userId}",
                    Transformation = new Transformation()
                        .Width(250)
                        .Height(300)
                        .Crop("fill")
                        .Chain()
                        .Quality("auto")
                        .FetchFormat("auto")
                };

                uploadResult = await cloudinary.UploadAsync(uploadParams);
            }

            if (uploadResult.Error != null)
                return Result<string>.Failure(uploadResult.Error.Message);

            var urlPhoto = uploadResult.SecureUrl.AbsoluteUri;
            await _userRepository.UploadPhoto(userId, urlPhoto);

            return Result<string>.Success(urlPhoto, "Photo Up");
        }
        catch (Exceptions.IdNotFoundException ex)
        {
            return Result<string>.Failure(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred while is uploading photo. {ex.InnerException?.Message ?? ex.Message}");
        }
    }

    public async Task<Result<List<string>>> UploadPhotoOfDocument(Guid userId, List<IFormFile> file, CancellationToken cancellationToken)
    {
        try
        {
            if (file == null || !file.Any())
                throw new ArgumentNullException(nameof(file));

            var uploadUrls = new List<string>();

            foreach (var item in file)
            {
                if(item.Length <= 0) continue;
                
                ImageUploadResult uploadResult;
                await using var stream = item.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(item.FileName, stream),
                    Folder = $"/users/{userId}/document_photo",
                    Transformation = new Transformation()
                        .Width(600)
                        .Height(400)
                        .Crop("scale")
                        .Chain()
                        .Quality("auto")
                        .FetchFormat("auto")
                };

                    uploadResult = await cloudinary.UploadAsync(uploadParams);
                
                if (uploadResult.Error != null)
                    return Result<List<string>>.Failure(uploadResult.Error.Message);
                
                var urlPhoto = uploadResult.SecureUrl.AbsoluteUri;
                uploadUrls.Add(urlPhoto);
                
                await _userRepository.UploadPhotoOfDocument(userId, urlPhoto, urlPhoto);

                
            }
            return Result<List<string>>.Success(uploadUrls, "Document photo up");
            
        }
        catch (Exceptions.IdNotFoundException ex)
        {
            return Result<List<string>>.Failure(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred while is uploading photo. {ex.InnerException?.Message ?? ex.Message}");
        }
    }
}