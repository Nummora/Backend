using System.Text.Json.Serialization;

namespace Nummora.Domain.Entities;

public class UserRole
{
    public Guid Id { get; set; }
    //Relations
    public Guid UserId { get; set; }
    
    [JsonIgnore]
    public User User { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; } 
    
    public Guid RoleId { get; set; }
    
    [JsonIgnore]
    public Role Role { get; set; }
}