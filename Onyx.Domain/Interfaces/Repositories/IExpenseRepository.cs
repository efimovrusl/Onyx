using Onyx.Domain.Models;

namespace Onyx.Domain.Interfaces.Repositories;

public interface IExpenseRepository
{
    Task<Expense> GetById(Guid id);
    Task<List<Expense>> GetByGroup(Guid groupId);
    Task<List<Expense>> GetByUser(Guid userId);
    
    Task Insert(Expense expense, List<Payer> payers, List<Consumer> consumers);
    Task Update(Guid id, string description, decimal amount);
    Task Delete(Guid id);
    
    Task<List<Payer>> GetPayers(Guid expenseId);
    Task<List<Consumer>> GetConsumers(Guid expenseId);
    
    Task UpdatePayers(Guid expenseId, List<Payer> payers);
    Task UpdateConsumers(Guid expenseId, List<Consumer> consumers);
}