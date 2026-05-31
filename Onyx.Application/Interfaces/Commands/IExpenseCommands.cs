using Onyx.Domain.Enums;
using Onyx.Domain.Models;

namespace Onyx.Application.Interfaces.Commands;

public interface IExpenseCommands
{
    Task<Expense> AddExpense(Guid? groupId, string description, decimal amount, 
        Currency currency, List<Payer> payers, List<Consumer> consumers);
    [Obsolete("Not implemented yet")]
    Task UpdateExpenseDescription(Expense expense);
    [Obsolete("Not implemented yet")]
    Task UpdatePayers(Guid expenseId, List<Payer> payers);
    [Obsolete("Not implemented yet")]
    Task UpdateConsumers(Guid expenseId, List<Consumer> consumers);
    [Obsolete("Not implemented yet")]
    Task DeleteExpense(Guid expenseId);
}