using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface ILoanRepository
{
    Task<List<LoanParticipation>> GetLoanParticipation();
    Task<LoanParticipation> CreateLoanParticipation(LoanParticipationDto loanParticipationDto);
    Task<List<Loan>> GetLoans();
    Task<Loan> CreateLoan(LoanDto loandto);
}