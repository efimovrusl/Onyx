using Onyx.Domain.Models;

namespace Onyx.Domain.Interfaces.Queries;

public interface IExpenseQueries
{
    Task<Expense> GetExpenseById(Guid expenseId);
    Task<List<Expense>> GetGroupExpenses(Guid groupId);
    Task<List<Expense>> GetUserExpenses(Guid userId);
}