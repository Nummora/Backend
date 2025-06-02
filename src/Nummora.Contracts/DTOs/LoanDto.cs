using Nummora.Contracts.Enums;

namespace Nummora.Contracts.DTOs;

public class LoanDto
{
    public DateTime StartDateLoan { get; set; }
    public DateTime DeadlineDate { get; set; }
    public int NumberInstallments { get; set; }
    public LoanStatus Status { get; set; }
}