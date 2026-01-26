using Onyx.Domain.Models;

namespace Onyx.Domain.Interfaces.Commands;

public interface IExpenseCommands
{
    Task<Expense> AddExpense(Guid groupId, Payer payer, List<Consumer> consumers, string description);
    Task<Expense> AddExpense(Guid groupId, List<Payer> payers, List<Consumer> consumers, string description);
    Task UpdateExpense(Expense expense);
    Task DeleteExpense(Guid expenseId);
}