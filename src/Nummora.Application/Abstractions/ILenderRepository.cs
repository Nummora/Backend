using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface ILenderRepository
{
    Task<Lender> GetLender(Guid lenderId);
    Task<Lender> CreateLender(LenderDto lenderDto, Guid userId);
}