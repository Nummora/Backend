using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Contracts.DTOs;

namespace Nummora.Api.Controllers.Wallets;

[ApiController]
[Route("api")]
public class WalletCreateController(IUserWalletService _userWalletService) : ControllerBase
{
    /// <summary>
    /// Add wallets to user
    /// </summary>
    /// <param name="userWalletDto"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPost("wallets/{userId}")]
    public async Task<IActionResult> CreateWallet(UserWalletDto userWalletDto, Guid userId)
    {
        var result = await _userWalletService.AddWalletToUserAsync(userWalletDto, userId);
        return Ok(result.Message);
    }
}