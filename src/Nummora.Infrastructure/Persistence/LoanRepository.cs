using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Contracts.Enums;
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