using Onyx.Domain.Interfaces.Queries;
using Onyx.Domain.Interfaces.Repositories;
using Onyx.Domain.Models;

namespace Onyx.Application.Queries;

public class ExpenseQueries(IExpenseRepository expenseRepository, IGroupRepository groupRepository) : IExpenseQueries
{
    public async Task<Expense> GetExpenseById(Guid expenseId)
    {
        return await expenseRepository.GetById(expenseId);
    }

    public async Task<List<Expense>> GetGroupExpenses(Guid groupId)
    {
        return await expenseRepository.GetByGroup(groupId);
    }

    public async Task<List<Expense>> GetPayerExpenses(Guid groupId, Guid userId)
    {
        return await expenseRepository.GetByPayerId(groupId, userId);
    }

    public async Task<List<Expense>> GetConsumerExpenses(Guid groupId, Guid userId)
    {
        throw new NotImplementedException();
    }
}