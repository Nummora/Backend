using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface ILenderService
{
    Task<Result<Lender>> GetLender(Guid lenderId);
    Task<Result<Lender>> CreateLender(LenderDto lenderDto, Guid userId);
}