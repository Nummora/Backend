using Nummora.Application.Abstractions;
using Nummora.Domain.Entities;
using Nummora.Infrastructure.Data;

namespace Nummora.Infrastructure.Persistence;

public class TokenRepository(ApplicationDbContext _context) : ITokenRepository
{
    public async Task<object> SaveToken(UserToken userToken)
    {
        var token = _context.UserTokens.Add(userToken);
        await _context.SaveChangesAsync();
        return token;
    }
}