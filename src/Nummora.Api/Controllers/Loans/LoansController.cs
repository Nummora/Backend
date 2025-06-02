using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;

namespace Nummora.Api.Controllers.Loans;

[ApiController]
[Route("api")]
public class LoansController(ILoanService loanService) : ControllerBase
{
    [HttpGet("loanparticipations")]
    public async Task<IActionResult> GetLoanParticipations()
    {
        var result = await loanService.GetLoanParticipationAsync();
        if(!result.IsSuccess)
            return NotFound(result.Message);
        
        return Ok(result.Data);
    }

    [HttpGet("loans")]
    public async Task<IActionResult> GetLoans()
    {
        var result = await loanService.GetLoansAsync();
        if(!result.IsSuccess)
            return NotFound(result.Message);
        
        return Ok(result.Data);
    }
}