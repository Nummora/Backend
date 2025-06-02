using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface ILoanRepository
{
    Task<List<LoanParticipation>> GetLoanParticipation();
    Task<List<Loan>> GetLoans();
    Task<List<LoanContract>> GetLoanContracts();
    Task<LoanContract> CreateLoanContract(LoanContractDto loanContractDto, Guid loanId);
    Task<LoanParticipation> CreateLoanParticipation(LoanParticipationDto loanParticipationDto);
    Task<Loan> CreateLoan(LoanDto loandto);
}