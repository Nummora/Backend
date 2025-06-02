using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IUserWalletService
{
    Task<Result<List<UserWallet>>> GetWalletAsync();
    Task<Result<UserWallet>> GetUserWallet(Guid userId);
    Task<Result<object>> AddWalletToUserAsync(UserWalletDto userWalletDto, Guid userId);
    Task<Result<bool>> DesactivateUserWalletAsync(Guid userId);
}