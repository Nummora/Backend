using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;

namespace Nummora.Api.Controllers.Lenders;

[ApiController]
[Route("api")]
public class LenderCreateController(ILenderService _lenderService) : ControllerBase
{
    [HttpPost("lenders")]
    public async Task<IActionResult> CreateLender([FromBody] LenderDto lenderDto, Guid userId)
    {
        var result = await _lenderService.CreateLender(lenderDto, userId);
        return Ok(result.Message);
    }
}