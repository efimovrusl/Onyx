using Onyx.Domain.Interfaces.Queries;
using Onyx.Domain.Interfaces.Repositories;
using Onyx.Domain.Models;

namespace Onyx.Application.Queries;

public class ExpenseQueries(IExpenseRepository expenseRepository) : IExpenseQueries
{
    public async Task<Expense> GetExpenseById(Guid expenseId)
    {
        return await expenseRepository.GetById(expenseId);
    }

    public Task<List<Expense>> GetGroupExpenses(Guid groupId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Expense>> GetUserExpenses(Guid userId)
    {
        throw new NotImplementedException();
    }
}