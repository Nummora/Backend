using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Api.Controllers.Users;

[ApiController]
[Route("api/")]
public class UserUpdateController(IUserService _userService) : ControllerBase
{
    /// <summary>
    /// Update field of users
    /// </summary>
    /// <param name="userRegisterDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("users")]
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
    [HttpPost("users/{userId}/photo/")]
    public async Task<IActionResult> UploadUserPhoto(Guid userId, IFormFile file, CancellationToken cancellationToken)
    {
        var result = await _userService.UploadPhotoAsync(userId, file, cancellationToken);
        
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(new { Photo = result.Data });
    }

    
    /// <summary>
    /// Upload document photo to verify identity
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="file"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("users/{userId}/document/photos")]
    public async Task<IActionResult> UploadUserDocumentPhoto(Guid userId, List<IFormFile> file, CancellationToken cancellationToken)
    {
        var result = await _userService.UploadPhotoOfDocument(userId, file, cancellationToken);
        
        if(!result.IsSuccess)
            return BadRequest(result.Message);
        
        return Ok(result.Data);
    }
}