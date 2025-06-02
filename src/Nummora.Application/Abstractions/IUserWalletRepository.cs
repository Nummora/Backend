using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IUserWalletRepository
{
    Task<List<UserWallet>> GetWallets();
    Task<UserWallet> GetUserWallet(Guid userId);
    Task<UserWallet> AddWalletToUser(UserWalletDto userWalletDto, Guid userId);
    Task UpdateWallet(UserWallet userWallet);
}