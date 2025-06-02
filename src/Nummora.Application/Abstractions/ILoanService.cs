using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface ILoanService
{
    Task<Result<List<LoanParticipation>>> GetLoanParticipationAsync();
    Task<Result<LoanParticipation>> CreateLoanParticipation(LoanParticipationDto loanParticipationDto);
    Task<Result<List<Loan>>> GetLoansAsync();
    Task<Result<Loan>> CreateLoan(LoanDto loandto);
}