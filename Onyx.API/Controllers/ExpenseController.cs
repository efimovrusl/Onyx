using Microsoft.AspNetCore.Mvc;
using Onyx.Domain.Enums;
using Onyx.Domain.Interfaces.Commands;
using Onyx.Domain.Interfaces.Queries;
using Onyx.Domain.Models;

namespace Onyx.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController(
    IExpenseQueries queries,
    IExpenseCommands commands
    ) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetExpense(Guid id)
    {
        var expense = await queries.GetExpenseById(id);
        return Ok(expense);
    }

    [HttpGet("group/{groupId}")]
    public async Task<ActionResult<List<Expense>>> GetGroupExpenses(Guid groupId)
    {
        var expenses = await queries.GetGroupExpenses(groupId);
        return Ok(expenses);
    }
    
    [HttpPost]
    public async Task<ActionResult<Expense>> AddExpense([FromBody] AddExpenseRequest request)
    {
        var expense = await commands.AddExpense(
            request.GroupId,
            request.Description,
            request.Amount,
            request.Currency,
            request.Payers,
            request.Consumers
        );
        
        return Ok(expense);
    }
}

public record AddExpenseRequest(
    Guid? GroupId,
    string Description,
    decimal Amount,
    Currency Currency,
    List<Payer> Payers,
    List<Consumer> Consumers
);