using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Contracts.Enums;
using Nummora.Domain;
using Nummora.Domain.Entities;
using Nummora.Infrastructure.Data;

namespace Nummora.Infrastructure.Persistence;

public class LoanRepository(ApplicationDbContext _context, IMapper _mapper) : ILoanRepository
{
    public async Task<List<LoanParticipation>> GetLoanParticipation()
    {
        var loan = await _context.LoanParticipations.Include(l => l.Debtor)
            .Include(l => l.Lender)
            .Include(l => l.Loan)
            .Include(l => l.Lender)
            .Include(l => l.UserWallet).ToListAsync();
        return loan;
    }

    public async Task<LoanContract> CreateLoanContract(LoanContractDto loanContractDto, Guid loanId)
    {
        var loanContract = _mapper.Map<LoanContract>(loanContractDto);
        loanContract.Id = Guid.NewGuid();
        loanContract.CreateAt = DateTime.UtcNow;
        loanContract.LoanId = loanId;
        
        _context.LoanContracts.Add(loanContract);
        await _context.SaveChangesAsync();
        return loanContract;
    }

    public async Task<LoanParticipation> CreateLoanParticipation(LoanParticipationDto loanParticipationDto)
    {
        var loanParticipation = _mapper.Map<LoanParticipation>(loanParticipationDto);
        loanParticipation.Id = Guid.NewGuid();
        loanParticipation.CreatedAt = DateTime.UtcNow;
        
        _context.LoanParticipations.Add(loanParticipation);
        await _context.SaveChangesAsync();
        return loanParticipation;
    }

    public async Task<List<Loan>> GetLoans()
    {
        var loan = await _context.Loans
            .Include(l => l.LoanContracts)
            .Include(l => l.LoanFinancialDetails)
            .Where(l => l.Status == LoanStatus.Pending).ToListAsync();

        return loan;
    }

    public async Task<List<LoanContract>> GetLoanContracts()
    {
        var loanContract = await _context.LoanContracts.Include(lc => lc.Loan).ToListAsync();
        return loanContract;
    }

    public async Task<Loan> CreateLoan(LoanDto loandto)
    {
        var loan = _mapper.Map<Loan>(loandto);
        loan.Id = Guid.NewGuid();
        loan.CreatedAt = DateTime.UtcNow;
        
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();
        return loan;
    }
}