using AutoMapper;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserRegisterDto>()
            .ForAllMembers(opt => opt.Condition(src => src != null));
        
        CreateMap<UserRegisterDto, User>();
    }
}