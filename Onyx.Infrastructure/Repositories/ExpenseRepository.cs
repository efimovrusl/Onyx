using Microsoft.EntityFrameworkCore;
using Onyx.Domain.Enums;
using Onyx.Domain.Interfaces.Repositories;
using Onyx.Domain.Models;
using Onyx.Infrastructure.Context;

namespace Onyx.Infrastructure.Repositories;

public class ExpenseRepository(SpendingDbContext db) : IExpenseRepository
{
    public async Task<Expense> GetById(Guid id)
    {
        var dbExpense = await db.Expenses
                            .Include(e => e.ExpensesPayers)
                            .Include(e => e.ExpensesConsumers)
                            .FirstOrDefaultAsync(e => e.Id == id) 
                        ?? throw new Exception($"Expense {id} not found.");
    
        return new Expense(
            dbExpense.Id, 
            dbExpense.GroupId, 
            dbExpense.Description,
            dbExpense.Amount, 
            dbExpense.Currency, 
            dbExpense.CreatedAt,
            dbExpense.ExpensesPayers.Select(p => new Payer(p.PayerId, p.Amount, p.Currency)).ToList(),
            dbExpense.ExpensesConsumers.Select(c => new Consumer(c.ConsumerId, c.DebtShare!.Value)).ToList()
        );
    }

    public async Task<List<Expense>> GetByGroup(Guid groupId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Expense>> GetByUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Expense> Insert(Expense expense)
    {
        var dbExpense = new DbModels.Expense
        {
            Id = expense.Id,
            GroupId = expense.GroupId,
            Description = expense.Description,
            Amount = expense.Amount,
            Currency = expense.Currency,
            CreatedAt = expense.CreatedAt
        };
    
        db.Expenses.Add(dbExpense);
    
        // Create payer relationships
        var dbPayers = expense.Payers.Select(p => new DbModels.ExpensesPayer
        {
            ExpenseId = expense.Id,
            PayerId = p.UserId,
            Amount = p.Amount,
            Currency = p.Currency
        }).ToList();
    
        db.ExpensesPayers.AddRange(dbPayers);
    
        // Create consumer relationships
        var dbConsumers = expense.Consumers.Select(c => new DbModels.ExpensesConsumer
        {
            ExpenseId = expense.Id,
            ConsumerId = c.UserId,
            DebtShare = c.Share
        }).ToList();
    
        db.ExpensesConsumers.AddRange(dbConsumers);
    
        // Save all changes
        await db.SaveChangesAsync();
    
        // Return the domain model (already have all the data)
        return expense;
    }

    public async Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Payer>> GetPayers(Guid expenseId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Consumer>> GetConsumers(Guid expenseId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateDescription(Guid id, string description)
    {
        throw new NotImplementedException();
    }

    public async Task UpdatePayers(Guid expenseId, List<Payer> payers)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateConsumers(Guid expenseId, List<Consumer> consumers)
    {
        throw new NotImplementedException();
    }
}