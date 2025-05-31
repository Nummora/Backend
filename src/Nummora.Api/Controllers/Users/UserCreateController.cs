using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;

namespace Nummora.Api.Controllers.Users;

[ApiController]
[Route("api/[controller]")]
public class UserCreateController(IUserService _userService) : ControllerBase
{
    /// <summary>
    /// Create new user
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateNewUser([FromBody]UserRegisterDto userRegisterDto)
    {
        var result = await _userService.CreateUserAsync(userRegisterDto);
        return Ok(result.Data);
    }

    /// <summary>
    /// Login
    /// </summary>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDto loginDto)
    {
        var result = await _userService.LoginAsync(loginDto);
        
        if (!result.IsSuccess)
            Unauthorized(result.Message);
        
        return Ok(result.Message);
    }
}