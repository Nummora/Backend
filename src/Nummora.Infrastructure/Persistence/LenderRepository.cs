using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;
using Nummora.Infrastructure.Data;

namespace Nummora.Infrastructure.Persistence;

public class LenderRepository(ApplicationDbContext _context, IMapper _mapper) : ILenderRepository
{
    public async Task<Lender> GetLender(Guid lenderId)
    {
        var lender = await _context.Lenders.FirstOrDefaultAsync(l => l.Id == lenderId);
        return lender;
    }

    public async Task<Lender> CreateLender(LenderDto lenderDto, Guid userId)
    {
        var lender = _mapper.Map<Lender>(lenderDto);
        lender.Id = Guid.NewGuid();
        lender.UserId = userId;
        
        
        _context.Lenders.Add(lender);
        await _context.SaveChangesAsync();
        return lender;
    }
}