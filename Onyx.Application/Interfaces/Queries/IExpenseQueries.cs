using Onyx.Domain.Models;

namespace Onyx.Application.Interfaces.Queries;

public interface IExpenseQueries
{
    Task<Expense> GetExpenseById(Guid expenseId);
    Task<List<Expense>> GetGroupExpenses(Guid groupId);
    Task<List<Expense>> GetPayerExpenses(Guid groupId, Guid userId);
    [Obsolete("Not implemented yet")]
    Task<List<Expense>> GetConsumerExpenses(Guid groupId, Guid userId);
}