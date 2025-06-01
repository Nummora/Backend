namespace Nummora.Domain.Entities;

public class LoanParticipation
{
    public Guid Id { get; set; }
    
    //Relations
    public Guid DebtorId { get; set; }
    public Debtor Debtor { get; set; }
    
    public Guid LenderId { get; set; }
    public Lender Lender { get; set; }
    
    public Guid LoanId { get; set; }
    public Loan Loan { get; set; }
    
    public Guid UserWalletId { get; set; }
    public  UserWallet UserWallet { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}