using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;

namespace Nummora.Api.Controllers.Loans;

[ApiController]
[Route("api")]
public class LoansController(ILoanService _loanService) : ControllerBase
{
    [HttpGet("loanparticipations")]
    public async Task<IActionResult> GetLoanParticipations()
    {
        var result = await _loanService.GetLoanParticipationAsync();
        if(!result.IsSuccess)
            return NotFound(result.Message);
        
        return Ok(result.Data);
    }

    [HttpGet("loans")]
    public async Task<IActionResult> GetLoans()
    {
        var result = await _loanService.GetLoansAsync();
        if(!result.IsSuccess)
            return NotFound(result.Message);
        
        return Ok(result.Data);
    }

    [HttpGet("loancontracts")]
    public async Task<IActionResult> GetLoanContracts()
    {
        var result = await _loanService.GetLoanContracts();
        return Ok(result.Data);
    }
}