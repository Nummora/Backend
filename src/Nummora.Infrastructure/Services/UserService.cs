using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;
using Nummora.Domain.Exceptions;

namespace Nummora.Infrastructure.Services;

public class UserService(IUserRepository _userRepository) : IUserService
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

    public async Task<Result<User>> GetUserByIdAsync(Guid id)
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

    public async Task<Result<User>> CreateUserAsync(UserRegisterDto userRegisterDto)
    {
        try
        {
            var newUser = await _userRepository.CreateUser(userRegisterDto);
            return Result<User>.Success(newUser, "User Created");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred creating user {e.InnerException?.Message ?? e.Message}");
        }
    }

    public Task<Result<User>> UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<User>> LoginAsync(UserDto loginDto)
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
}