using AutoMapper;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Mappers;

public class WalletProfile : Profile
{
    public WalletProfile()
    {
        CreateMap<UserWalletDto, UserWallet>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}