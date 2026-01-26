using Microsoft.AspNetCore.Mvc;
using Onyx.Domain.Enums;
using Onyx.Domain.Interfaces.Commands;

namespace Onyx.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SettlementController(
    ISettlementCommands commands
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SettleDebt([FromBody] SettleDebtRequest request)
    {
        await commands.SettleDebt(
            request.GroupId,
            request.PayerId,
            request.ReceiverId,
            request.Amount,
            request.Currency
        );
        return Ok();
    }
}

public record SettleDebtRequest(Guid GroupId, Guid PayerId, Guid ReceiverId, decimal Amount, Currency Currency);