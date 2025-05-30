namespace Nummora.Domain.Entities;

public class LoanContract
{
    public Guid Id { get; set; }
    public string ContractUrl { get; set; }
    public string InsuranceContract { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    
    //Relations
    public Guid LoanId { get; set; }
    public Loan Loan { get; set; }
}