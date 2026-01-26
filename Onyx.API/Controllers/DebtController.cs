using Microsoft.AspNetCore.Mvc;
using Onyx.Domain.Interfaces.Queries;
using Onyx.Domain.Models;

namespace Onyx.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DebtController(
    IDebtQueries queries
) : ControllerBase
{
    [HttpGet("group/{groupId}/user/{userId}/total")]
    public async Task<ActionResult<decimal>> GetTotalGroupDebt(Guid groupId, Guid userId)
    {
        var debt = await queries.GetTotalGroupDebt(userId, groupId);
        return Ok(debt);
    }

    [HttpGet("group/{groupId}/user/{userId}/owed")]
    public async Task<ActionResult<decimal>> GetTotalGroupOwed(Guid groupId, Guid userId)
    {
        var owed = await queries.GetTotalGroupOwed(userId, groupId);
        return Ok(owed);
    }

    [HttpGet("group/{groupId}/user/{userId}")]
    public async Task<ActionResult<List<(User user, decimal debt)>>> GetGroupDebts(Guid groupId, Guid userId)
    {
        var debts = await queries.GetGroupDebts(groupId, userId);
        return Ok(debts);
    }

    // [HttpGet("user/{userId}/global")]
    // public async Task<ActionResult<List<(User user, decimal debt)>>> GetGlobalDebts(Guid userId)
    // {
    //     var debts = await queries.GetGlobalDebts(userId);
    //     return Ok(debts);
    // }
}