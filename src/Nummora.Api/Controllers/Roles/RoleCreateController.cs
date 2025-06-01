using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Domain;

namespace Nummora.Api.Controllers.Roles;

[ApiController]
[Route("api/[controller]")]
public class RoleCreateController(IRoleService _roleService) : ControllerBase
{
    [HttpPost]
    public async Task<OkObjectResult> CreateNewRole([FromBody] RoleCreateDto dto)
    {
        var result = await _roleService.CreateRoleAsync(dto);
        return Ok(result.Message);
    }
}