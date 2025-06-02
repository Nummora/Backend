using Microsoft.AspNetCore.Mvc;
using Nummora.Application.Abstractions;
using Nummora.Domain.Entities;

namespace Nummora.Api.Controllers.Wallets;

[ApiController]
[Route("api")]
public class WalletUpdateController(IUserWalletService _walletService) : ControllerBase
{
    /// <summary>
    /// Change status of wallet as such as IsActive = false
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPatch]
    public async Task<IActionResult> DesactivateWallet(Guid userId)
    {
        var result = await _walletService.DesactivateUserWalletAsync(userId);
        return Ok(result.Message);
    }
}