using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Api.Controllers.Loans;

[ApiController]
[Route("api")]
public class LoanCreateController(ILoanService _loanService) : ControllerBase
{
    [HttpPost("loans")]
    public async Task<IActionResult> CreateLoan([FromBody] LoanDto loanDto)
    {
        var result = await _loanService.CreateLoan(loanDto);
        return Ok(result.Data);
    }

    [HttpPost("loanparticipations")]
    public async Task<IActionResult> CreateLoanParticipation(LoanParticipationDto loanParticipationDto)
    {
        var result = await _loanService.CreateLoanParticipation(loanParticipationDto);
        return Ok(result.Data);
    }
}