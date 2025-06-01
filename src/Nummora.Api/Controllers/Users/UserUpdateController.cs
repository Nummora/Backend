using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Api.Controllers.Users;

[ApiController]
[Route("api/[controller]")]
public class UserUpdateController(IUserService _userService) : ControllerBase
{
    /// <summary>
    /// Update field of users
    /// </summary>
    /// <param name="userRegisterDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    public async Task<IActionResult> UpdateUser(UserRegisterDto userRegisterDto, CancellationToken cancellationToken)
    {
        var result = await _userService.UpdateUserAsync(userRegisterDto, cancellationToken);
        return Ok(result.Message);
    }

    /// <summary>
    /// Upload photo
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="file"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("photo/{userId}")]
    public async Task<IActionResult> UploadUserPhoto(Guid userId, IFormFile file, CancellationToken cancellationToken)
    {
        var result = await _userService.UploadPhoto(userId, file, cancellationToken);
        
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(new { Photo = result.Data });
    }
}