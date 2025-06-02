namespace Nummora.Contracts.DTOs;

public class LoanParticipationDto
{
    public Guid DebtorId { get; set; }
    public Guid LenderId { get; set; }
    public Guid LoanId { get; set; }
    public Guid UserWalletId { get; set; }
}