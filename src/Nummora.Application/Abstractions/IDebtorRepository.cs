using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IDebtorRepository
{
    Task<Debtor> GetDebtorById(Guid debtorId);
    Task<Debtor> CreateDebtor(DebtorDto debtorDto, Guid userId);
}