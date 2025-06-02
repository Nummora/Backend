using Nummora.Contracts.DTOs;
using Nummora.Domain;
using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface IDebtorService
{
    Task<Result<Debtor>> GetDebtorById(Guid debtorId);
    Task<Result<Debtor>> CreateDebtorAsync(DebtorDto debtorDto, Guid userId);
}