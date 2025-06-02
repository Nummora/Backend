using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;

namespace Nummora.Api.Controllers.Lenders;

[ApiController]
[Route("api")]
public class LendersController(ILenderService _lenderService) : ControllerBase
{
    [HttpGet("lenders/{lenderId}")]
    public async Task<IActionResult> GetLender(Guid lenderId)
    {
        var result = await _lenderService.GetLender(lenderId);
        return Ok(result.Data);
    }
}