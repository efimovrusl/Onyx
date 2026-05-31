using Onyx.Domain.Models;

namespace Onyx.Application.Interfaces.Repositories;

public interface IExpenseRepository
{
    Task<Expense> GetById(Guid id);
    Task<List<Expense>> GetByGroup(Guid groupId);
    Task<List<Expense>> GetByPayerId(Guid groupId, Guid payerId);
    Task<List<Expense>> GetByConsumerId(Guid groupId, Guid consumerId);
    
    Task<Expense> Insert(Expense expense);
    [Obsolete("Not implemented yet")]
    Task Delete(Guid id);
    
    [Obsolete("Not implemented yet")]
    Task<List<Payer>> GetPayers(Guid expenseId);
    [Obsolete("Not implemented yet")]
    Task<List<Consumer>> GetConsumers(Guid expenseId);

    [Obsolete("Not implemented yet")]
    Task UpdateDescription(Guid id, string description);
    [Obsolete("Not implemented yet")]
    Task UpdatePayers(Guid expenseId, List<Payer> payers);
    [Obsolete("Not implemented yet")]
    Task UpdateConsumers(Guid expenseId, List<Consumer> consumers);
}