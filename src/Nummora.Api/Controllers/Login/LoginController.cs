using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;

namespace Nummora.Api.Controllers.Login;

[ApiController]
[Route("api")]
public class LoginController(IUserService _userService) : ControllerBase
{
    /// <summary>
    /// Login
    /// </summary>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDto loginDto, CancellationToken cancellationToken)
    {
        var result = await _userService.LoginAsync(loginDto, cancellationToken);
        
        if (!result.IsSuccess)
            Unauthorized(result.Message);
        
        return Ok(result.Data);
    }
}