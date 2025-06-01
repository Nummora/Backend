using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;

namespace Nummora.Api.Controllers.Users;

[ApiController]
[Route("api")]
public class UserDeleteController(IUserService _userService) : ControllerBase
{
    /// <summary>
    /// Delete user of database by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("users/{id}")]
    public async Task<IActionResult> DeleteUserById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _userService.DeleteUserAsync(id, cancellationToken);
        return Ok(result.Message);
    }
    
}