using System.Security.Cryptography;
using System.Text;
using Nummora.Application.Abstractions;

namespace Nummora.Infrastructure.Services;

public class TokenService : ITokenService
{
    public string GenerateToken()
    {
        var token = Guid.NewGuid().ToString();
        using var shaAlgoritm = SHA256.Create();
        var hash = shaAlgoritm.ComputeHash(Encoding.UTF8.GetBytes(token));
        return Convert.ToHexString(hash);
    }

    public (string accessToken, string refreshToken) GenerateTokenAndRefreshToken()
    {
        var accessToken = GenerateToken();
        var refreshToken = GenerateToken();
        return (accessToken, refreshToken);
    }
}