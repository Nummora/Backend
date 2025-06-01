using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;

namespace Nummora.Api.Controllers.Roles;

[ApiController]
[Route("api")]
public class RolesController(IRoleService _roleService) : ControllerBase
{
    [HttpGet("roles")]
    public async Task<IActionResult> GetRoles()
    {
        var result = await _roleService.GetRolesAsync();
        return Ok(result.Data);
    }
}