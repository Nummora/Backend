using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;
using Nummora.Domain.Exceptions;

namespace Nummora.Infrastructure.Services;

public class LoanService(ILoanRepository loanRepository) : ILoanService
{
    public async Task<Result<List<LoanParticipation>>> GetLoanParticipationAsync()
    {
        try
        {
            var loan = await loanRepository.GetLoanParticipation();
            if(loan == null || !loan.Any())
                return Result<List<LoanParticipation>>.Failure("Loan participation not found");
            
            return Result<List<LoanParticipation>>.Success(loan,"Successfully retrieved loan participation");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred {e.InnerException?.Message ?? e.Message}");
        }
    }

    public async Task<Result<LoanParticipation>> CreateLoanParticipation(LoanParticipationDto loanParticipationDto)
    {
        try
        {
            if (loanParticipationDto == null)
                return Result<LoanParticipation>.Failure("Loan data is required.");
            
            var loan = await loanRepository.CreateLoanParticipation(loanParticipationDto);
            
            return Result<LoanParticipation>.Success(loan,"Successfully retrieved loan participation");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred {e.InnerException?.Message ?? e.Message}");
        }
    }

    public async Task<Result<List<Loan>>> GetLoansAsync()
    {
        try
        {
            var loan = await loanRepository.GetLoans();
            if(loan == null || !loan.Any())
                return Result<List<Loan>>.Failure("Loan not found");
            
            return Result<List<Loan>>.Success(loan,"Successfully retrieved loan participation");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred {e.InnerException?.Message ?? e.Message}");
        }
    }

    public async Task<Result<Loan>> CreateLoan(LoanDto loandto)
    {
        try
        {
            if (loandto == null)
                return Result<Loan>.Failure("Loan data is required.");
            
            var loan = await loanRepository.CreateLoan(loandto);
            
            return Result<Loan>.Success(loan,"Successfully retrieved loan participation");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred {e.InnerException?.Message ?? e.Message}");
        }
    }
}