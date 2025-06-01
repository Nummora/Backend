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

    public async Task<Result<User>> CreateUserAsync(UserRegisterDto userRegisterDto, CancellationToken cancellationToken = default)
    {
        try
        {
            var validate = userValidator.Validate(userRegisterDto);
            if(!validate.IsValid)
                return Result<User>.Failure(validate.Errors.ToString()??"It is not possible to create a user");

            
            var newUser = await _userRepository.CreateUser(userRegisterDto);
            return Result<User>.Success(newUser, "User Created");
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

    public async Task<Result<string>> UploadPhoto(Guid userId, IFormFile file, CancellationToken cancellationToken)
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
}