using AutoMapper;
using Nummora.Contracts.DTOs;
using Nummora.Domain.Entities;

namespace Nummora.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>();
    }
}