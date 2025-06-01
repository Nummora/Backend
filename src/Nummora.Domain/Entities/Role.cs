using System.Text.Json.Serialization;
using Nummora.Domain.Entities;

namespace Nummora.Domain.Entities;

public class Role
{
    public Guid Id { get; set; }
    public RoleUser Name { get; set; }
    public DateTime CreateAt { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<UserRole> UserRoles { get; set; }

    public enum RoleUser
    {
        None = 0,
        User = 1,
        Lender = 2,
    }
}