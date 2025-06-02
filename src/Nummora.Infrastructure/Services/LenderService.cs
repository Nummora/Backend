using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;
using Nummora.Domain.Exceptions;

namespace Nummora.Infrastructure.Services;

public class LenderService(ILenderRepository _lenderRepository) : ILenderService
{
    public async Task<Result<Lender>> GetLender(Guid lenderId)
    {
        try
        {
            var lender = await _lenderRepository.GetLender(lenderId);
            if(lender == null)
                return Result<Lender>.Failure("lender not found");

            return Result<Lender>.Success(lender, "lender retriened successfully");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred {e.InnerException?.Message ?? e.Message}");
        }
    }

    public async Task<Result<Lender>> CreateLender(LenderDto lenderDto, Guid userId)
    {
        try
        {
            var lender = await _lenderRepository.CreateLender(lenderDto, userId);
            if(lender == null)
                return Result<Lender>.Failure("lender not found");

            return Result<Lender>.Success(lender, "lender retriened successfully");
        }
        catch (Exception e)
        {
            throw new Exceptions.InternalServerErrorException($"An error occurred {e.InnerException?.Message ?? e.Message}");
        }
    }
}