using Nummora.Contracts.Enums;

namespace Nummora.Contracts.DTOs;

public class UserWalletDto
{
    public string Address { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public bool IsDefault { get; set; }
}