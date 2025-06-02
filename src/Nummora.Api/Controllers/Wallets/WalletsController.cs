using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;

namespace Nummora.Api.Controllers.Wallets;

[ApiController]
[Route("api")]
public class WalletsController(IUserWalletService _userWalletService) : ControllerBase
{
    /// <summary>
    /// List all wallets that exists in application
    /// </summary>
    /// <returns></returns>
    [HttpGet("wallets")]
    public async Task<IActionResult> GetWallets()
    {
        var result = await _userWalletService.GetWalletAsync();
        return Ok(result.Data);
    }

    /// <summary>
    /// Get wallet of user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("wallets/{userId}")]
    public async Task<IActionResult> GetWallet(Guid userId)
    {
        var result = await _userWalletService.GetUserWallet(userId);
        return Ok(result.Data);
    }
}