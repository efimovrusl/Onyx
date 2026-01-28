using Onyx.Domain.Enums;
using Onyx.Domain.Models;

namespace Onyx.Domain.Interfaces.Commands;

public interface IExpenseCommands
{
    Task<Expense> AddExpense(Guid? groupId, string description, decimal amount, 
        Currency currency, List<Payer> payers, List<Consumer> consumers);
    Task UpdateExpenseDescription(Expense expense);
    Task UpdatePayers(Guid expenseId, List<Payer> payers);
    Task UpdateConsumers(Guid expenseId, List<Consumer> consumers);
    Task DeleteExpense(Guid expenseId);
}