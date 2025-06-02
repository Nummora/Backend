using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;

namespace Nummora.Api.Controllers.Debtors;

[ApiController]
[Route("api")]
public class DebtorCreateController(IDebtorService _debtorService) : ControllerBase
{
    /// <summary>
    /// Create debtor
    /// </summary>
    /// <param name="debtorDto"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPost("debtors")]
    public async Task<IActionResult> CreateDebtorAsync([FromBody] DebtorDto debtorDto, Guid userId)
    {
        var result = await _debtorService.CreateDebtorAsync(debtorDto, userId);
        return Ok(result.Message);
    }
}