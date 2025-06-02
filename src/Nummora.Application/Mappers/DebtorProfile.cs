using AutoMapper;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Mappers;

public class DebtorProfile : Profile
{
    public DebtorProfile()
    {
        CreateMap<DebtorDto, Debtor>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}