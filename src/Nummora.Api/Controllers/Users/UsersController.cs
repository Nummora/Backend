using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Domain.Entities;

namespace Nummora.Api.Controllers.Users;

[ApiController]
[Route("api")]
public class UsersController(IUserService _userService) : ControllerBase
{
    /// <summary>
    /// Get all users in Nummora
    /// </summary>
    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _userService.GetUsersAsync();
        if (result.Data == null)
        {
            return NotFound("No users found");
        }
        return Ok(result.Data);
    }

    /// <summary>
    /// Get user by id
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _userService.GetUserByIdAsync(id, cancellationToken);
        return Ok(result.Data);
    }
}