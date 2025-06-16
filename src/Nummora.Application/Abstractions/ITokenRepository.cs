using Nummora.Domain.Entities;

namespace Nummora.Application.Abstractions;

public interface ITokenRepository
{
    Task<object> SaveToken(UserToken userToken);
}