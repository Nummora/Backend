using Nummora.Contracts.Enums;

namespace Nummora.Domain.Entities;

public class Loan
{
    public Guid Id { get; set; }
    public DateTime StartDateLoan { get; set; }
    public DateTime DeadlineDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int NumberInstallments { get; set; }
    public LoanStatus Status { get; set; }
    
    //Relations
    public virtual ICollection<LoanFinancialDetail> LoanFinancialDetails { get; set; }
    public virtual ICollection<LoanContract> LoanContracts { get; set; }
}