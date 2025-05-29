namespace Nummora.Domain.Entities;

public class Lender
{
    public Guid Id { get; set; }
    public decimal AvalaibleCapital { get; set; }
    
    //Relations
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public ICollection<LoanParticipation> LoanParticipations { get; set; }
}