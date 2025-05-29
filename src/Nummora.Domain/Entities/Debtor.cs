namespace Nummora.Domain.Entities;

public class Debtor
{
    public Guid Id { get; set; }
    public decimal LoanLimit { get; set; }
    public int ReputationScore { get; set; }
    
    //Relations
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public ICollection<LoanParticipation> LoanParticipations { get; set; }
}