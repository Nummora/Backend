namespace Nummora.Contracts.DTOs;

public class UserRegisterDto
{
    public string FirstName { get; set; }
    public string? SecondName { get; set; }
    public string FirstLastName { get; set; }
    public string? SecondLastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    public string NumberDocument  { get; set; }
    public string NumberPhone { get; set; }
}