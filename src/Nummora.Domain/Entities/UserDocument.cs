using System.Text.Json.Serialization;

namespace Nummora.Domain.Entities;

public class UserDocument
{
    public Guid Id { get; set; }
    public string FrontDocumentUrl { get; set; }
    public string BackDocumentUrl { get; set; }
    
    //Relations
    public Guid UserId { get; set; }
    
    [JsonIgnore]
    public User User { get; set; }
}