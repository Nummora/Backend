using Nummora.Contracts.Enums;

namespace Nummora.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string? SecondName { get; set; }
    public string FirstLastName { get; set; }
    public string? SecondLastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Photo  { get; set; }
    public string Description { get; set; }
    public string NumberDocument  { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public string NumberPhone { get; set; }
    public bool IsVerified { get; set; }
    public DocumentType DocumentType { get; set; }
    
    //Relations
    public ICollection<UserDocument> UserDocuments { get; set; }
    public ICollection<Lender> Lenders { get; set; }
    public ICollection<Debtor> Debtors { get; set; }
    public ICollection<UserWallet> UserWallets { get; set; }
    
    public ICollection<UserRole> UserRoles { get; set; }
}
