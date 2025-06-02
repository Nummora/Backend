using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;
using Nummora.Infrastructure.Data;

namespace Nummora.Infrastructure.Persistence;

public class DebtorRepository(ApplicationDbContext _context, IMapper _mapper) : IDebtorRepository
{
    public async Task<Debtor> GetDebtorById(Guid debtorId)
    {
        var debtor = await _context.Debtors.FirstOrDefaultAsync(d => d.Id == debtorId);
        return debtor;
    }

    public async Task<Debtor> CreateDebtor(DebtorDto debtorDto, Guid userId)
    {
        var debtor = _mapper.Map<Debtor>(debtorDto);
        debtor.Id = Guid.NewGuid();
        debtor.UserId = userId;
        
        
        _context.Debtors.Add(debtor);
        await _context.SaveChangesAsync();
        return debtor;
    }
}