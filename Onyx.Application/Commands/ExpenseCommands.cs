using Onyx.Domain.Enums;
using Onyx.Domain.Interfaces.Commands;
using Onyx.Domain.Interfaces.Repositories;
using Onyx.Domain.Models;

namespace Onyx.Application.Commands;

public class ExpenseCommands(
    IExpenseRepository expenseRepository
) : IExpenseCommands
{
    public async Task<Expense> AddExpense(Guid? groupId, string description, decimal amount, 
        Currency currency, List<Payer> payers, List<Consumer> consumers)
    {
        var newExpense = new Expense(
            Guid.CreateVersion7(), // time-ordered
            groupId,
            description,
            amount,
            currency,
            DateTime.UtcNow, // TODO: Use user's time-zone
            payers,
            consumers);
        
        return await expenseRepository.Insert(newExpense);
    }

    public async Task UpdateExpenseDescription(Expense expense)
    {
        await expenseRepository.UpdateDescription(expense.Id, expense.Description);
    }

    public async Task UpdatePayers(Guid expenseId, List<Payer> payers)
    {
        await expenseRepository.UpdatePayers(expenseId, payers);
    }

    public async Task UpdateConsumers(Guid expenseId, List<Consumer> consumers)
    {
        await expenseRepository.UpdateConsumers(expenseId, consumers);
    }

    public async Task DeleteExpense(Guid expenseId)
    {
        await expenseRepository.Delete(expenseId);
    }
}