using AutoMapper;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Mappers;

public class LoanProfile : Profile
{
    public LoanProfile()
    {
        CreateMap<LoanDto, Loan>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        
        CreateMap<LoanParticipationDto, LoanParticipation>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        
        CreateMap<LoanContractDto, LoanContract>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}