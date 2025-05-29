using Nummora.Domain.Enums;

namespace Nummora.Domain.Entities;

public class UserWallet
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public bool IsActive { get; set; }
    public bool IsDefault { get; set; }
    
    //Relations 
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public int CurrencyTypeId { get; set; }
    public ICollection<CurrencyType> CurrencyTypes { get; set; }
    public ICollection<LoanParticipation> LoanParticipations { get; set; }
}