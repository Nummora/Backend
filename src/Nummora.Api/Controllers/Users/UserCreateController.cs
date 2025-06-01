using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Api.Controllers.Users;

[ApiController]
[Route("api")]
public class UserCreateController(IUserService _userService) : ControllerBase
{
    /// <summary>
    /// Create new user
    /// </summary>
    /// <returns></returns>
    [HttpPost("users")]
    public async Task<IActionResult> CreateNewUser([FromBody]UserRegisterDto user, CancellationToken cancellationToken)
    {
        var result = await _userService.CreateUserAsync(user, cancellationToken);
        return Ok(result.Data);
    }
}