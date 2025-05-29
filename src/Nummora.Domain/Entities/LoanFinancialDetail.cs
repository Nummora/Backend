namespace Nummora.Domain.Entities;

public class LoanFinancialDetail
{
    public Guid Id { get; set; }
    public decimal TotalLoan  { get; set; }
    public decimal InstallmentValue { get; set; }
    public decimal LenderProfit { get; set; }
    public decimal ServiceFee { get; set; }
    public decimal InsuranceFee { get; set; }
    public int InterestRate { get; set; }
    
    //Relations
    public Guid LoanId { get; set; }
    public Loan Loan { get; set; }
}