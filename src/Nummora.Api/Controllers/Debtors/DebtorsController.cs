using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;

namespace Nummora.Api.Controllers.Debtors;

[ApiController]
[Route("api")]
public class DebtorsController(IDebtorService _debtorService) : ControllerBase
{
    /// <summary>
    /// Get debtor by id
    /// </summary>
    /// <param name="debtorId"></param>
    /// <returns></returns>
    [HttpGet("debtors/{debtorId}")]
    public async Task<IActionResult> GetDebtor(Guid debtorId)
    {
        var result = await _debtorService.GetDebtorById(debtorId);
        return Ok(result.Data);
    }
}