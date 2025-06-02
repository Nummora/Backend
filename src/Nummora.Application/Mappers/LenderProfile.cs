using AutoMapper;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Mappers;

public class LenderProfile : Profile
{
    public LenderProfile()
    {
        CreateMap<LenderDto, Lender>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}