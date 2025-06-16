namespace Nummora.Domain.Entities;

public class UserToken
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime RefreshExpiresAt { get; set; }
    
    public User User { get; set; }
}