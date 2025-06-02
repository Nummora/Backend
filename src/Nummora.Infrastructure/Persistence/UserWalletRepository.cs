using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;
using Nummora.Domain.Exceptions;
using Nummora.Infrastructure.Data;

namespace Nummora.Infrastructure.Persistence;

public class UserWalletRepository(ApplicationDbContext _context, IMapper _mapper) : IUserWalletRepository
{
    public async Task<List<UserWallet>> GetWallets()
    {
        var wallet = await _context.UserWallets
                                    .Include(uw => uw.User).ToListAsync();
        return wallet;
    }

    public async Task<UserWallet> GetUserWallet(Guid userId)
    {
        var wallet = await _context.UserWallets.FirstOrDefaultAsync(w => w.Id == userId);
        return wallet;
    }

    public async Task<UserWallet> AddWalletToUser(UserWalletDto userWalletDto, Guid userId)
    {
        var wallet = _mapper.Map<UserWallet>(userWalletDto);

        wallet.Id = Guid.NewGuid();
        wallet.CreateAt = DateTime.UtcNow;
        wallet.UpdateAt = DateTime.UtcNow;
        wallet.IsActive = true;
        wallet.UserId = userId;
        
        _context.UserWallets.Add(wallet);
        await _context.SaveChangesAsync();
        return wallet;
    }

    public async Task UpdateWallet(UserWallet userWallet)
    {
        _context.UserWallets.Update(userWallet);
        await _context.SaveChangesAsync();
    }
}