using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;
using Nummora.Domain.Exceptions;

namespace Nummora.Infrastructure.Services;

public class DebtorService(IDebtorRepository _debtorRepository) : IDebtorService
{
    public async Task<Result<Debtor>> GetDebtorById(Guid debtorId)
    {
        try
        {
            var debtor = await _debtorRepository.GetDebtorById(debtorId);
            if (debtor == null)
                return Result<Debtor>.Failure("debtor not found");
            
            return Result<Debtor>.Success(debtor, "Debtor retrieved successfully");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred while resolve service {e.InnerException?.Message ?? e.Message}");
        }
    }

    public async Task<Result<Debtor>> CreateDebtorAsync(DebtorDto debtorDto, Guid userId)
    {
        try
        {
            var debtor = await _debtorRepository.CreateDebtor(debtorDto, userId);
            if (debtor == null)
                return Result<Debtor>.Failure("debtor not found");
            
            return Result<Debtor>.Success(debtor, "Debtor retrieved successfully");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred while resolve service {e.InnerException?.Message ?? e.Message}");
        }
    }
}