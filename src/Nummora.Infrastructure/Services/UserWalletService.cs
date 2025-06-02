using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;
using Nummora.Domain.Exceptions;
using Nummora.Infrastructure.Persistence;

namespace Nummora.Infrastructure.Services;

public class UserWalletService(IUserWalletRepository _walletRepository) : IUserWalletService
{
    public async Task<Result<List<UserWallet>>> GetWalletAsync()
    {
        try
        {
            var wallet = await _walletRepository.GetWallets();
            if(wallet == null)
                return Result<List<UserWallet>>.Failure("No wallet found");

            return Result<List<UserWallet>>.Success(wallet, "Wallets retrieved successfully");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred while list wallets {e.InnerException?.Message ?? e.Message}");
        }
    }

    public async Task<Result<UserWallet>> GetUserWallet(Guid userId)
    {
        try
        {
            var wallet = await _walletRepository.GetUserWallet(userId);
            if(wallet == null)
                return Result<UserWallet>.Failure("No wallet found");
            
            return Result<UserWallet>.Success(wallet, "Wallet retrieved successfully");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred while list wallets {e.InnerException?.Message ?? e.Message}");
        }
    }

    public async Task<Result<object>> AddWalletToUserAsync(UserWalletDto userWalletDto, Guid userId)
    {
        try
        {
            var wallet = await _walletRepository.AddWalletToUser(userWalletDto, userId);
            return Result<object>.Success(wallet, "Wallet added successfully");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred while list wallets {e.InnerException?.Message ?? e.Message}");
        }
    }

    public async Task<Result<bool>> DesactivateUserWalletAsync(Guid userId)
    {
        try
        {
            var wallet = await _walletRepository.GetUserWallet(userId);
            if (wallet == null || !wallet.IsActive) return Result<bool>.Failure("No wallet found");
            
            wallet.IsActive = false;
            wallet.UpdateAt = DateTime.UtcNow;
            
            await _walletRepository.UpdateWallet(wallet);

            return Result<bool>.Success(true , "wallet desactivated successfully");

        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred while list wallets {e.InnerException?.Message ?? e.Message}");
        }
    }
}