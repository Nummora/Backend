using System.Text.Json.Serialization;
using Nummora.Contracts.Enums;

namespace Nummora.Contracts.DTOs;

public class UserRegisterDto
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? FirstLastName { get; set; }
    public string? SecondLastName { get; set; }
    public string? Photo  { get; set; }
    public int Age { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Description { get; set; }
    public DocumentType DocumentType { get; set; }
    
    public UserRoleType Role { get; set; }
    public string? NumberDocument  { get; set; }
    public string? NumberPhone { get; set; }
   
}