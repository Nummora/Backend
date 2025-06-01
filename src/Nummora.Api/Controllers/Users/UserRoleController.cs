using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Api.Controllers.Users;

[ApiController]
[Route("api/[controller]")]
public class UserRoleController(IUserRolService _rolService) : ControllerBase
{
    /// <summary>
    /// Add role to user
    /// </summary>
    /// <param name="userRole"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddRolToUser([FromBody]UserRoleDto userRoleDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _rolService.CreateUserRoleAsync(userRoleDto);
        return Ok(result.Message);
    }
}