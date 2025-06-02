using Nummora.Contracts.Enums;

namespace Nummora.Domain.Entities;

public class UserWallet
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public bool IsActive { get; set; }
    public bool IsDefault { get; set; }
    public CurrencyType CurrencyType { get; set; }
    
    //Relations 
    public Guid UserId { get; set; }
    public User User { get; set; }
    public virtual ICollection<LoanParticipation> LoanParticipations { get; set; }
}