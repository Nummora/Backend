using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface ILoanService
{
    Task<Result<List<LoanParticipation>>> GetLoanParticipationAsync();
    Task<Result<List<Loan>>> GetLoansAsync();
    Task<Result<List<LoanContract>>> GetLoanContracts();
    Task<Result<LoanContract>> CreateLoanContract(LoanContractDto loanContractDto, Guid loanId);
    Task<Result<LoanParticipation>> CreateLoanParticipation(LoanParticipationDto loanParticipationDto);
    Task<Result<Loan>> CreateLoan(LoanDto loandto);
}