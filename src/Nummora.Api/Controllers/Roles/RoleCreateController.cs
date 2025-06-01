using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Domain;

namespace Nummora.Api.Controllers.Roles;

[ApiController]
[Route("api")]
public class RoleCreateController(IRoleService _roleService) : ControllerBase
{
    [HttpPost("roles")]
    public async Task<OkObjectResult> CreateNewRole([FromBody] RoleCreateDto dto)
    {
        var result = await _roleService.CreateRoleAsync(dto);
        return Ok(result.Message);
    }
}