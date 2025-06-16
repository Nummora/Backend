namespace Nummora.Application.Abstractions;

public interface ITokenService
{
    string GenerateToken();
    (string accessToken, string refreshToken) GenerateTokenAndRefreshToken();
}