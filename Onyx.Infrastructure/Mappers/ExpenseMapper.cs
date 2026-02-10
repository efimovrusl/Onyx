namespace Onyx.Infrastructure.Mappers;

using Onyx.Domain.Models;
using Onyx.Infrastructure.DbModels;

public static class ExpenseMappings
{
    extension (DbModels.Expense db)
    {
        public Domain.Models.Expense ToDomain()
            => new(
                db.Id,
                db.GroupId,
                db.Description,
                db.Amount,
                db.Currency,
                db.CreatedAt,
                [.. db.ExpensesPayers.Select(static p => p.ToDomain())],
                [.. db.ExpensesConsumers.Select(static c => c.ToDomain())]
            );
    }

    extension (Domain.Models.Expense domain)
    {
        public DbModels.Expense ToDb()
            => new()
            {
                Id = domain.Id,
                GroupId = domain.GroupId,
                Description = domain.Description,
                Amount = domain.Amount,
                Currency = domain.Currency,
                CreatedAt = domain.CreatedAt
            };
    }

    extension (ExpensesPayer db)
    {
        public Payer ToDomain()
            => new(
                db.PayerId,
                db.Amount,
                db.Currency
            );
    }

    extension (Payer domain)
    {
        public ExpensesPayer ToDb(Guid expenseId)
            => new()
            {
                ExpenseId = expenseId,
                PayerId = domain.UserId,
                Amount = domain.Amount,
                Currency = domain.Currency
            };
    }

    extension (ExpensesConsumer db)
    {
        public Consumer ToDomain()
            => new(
                db.ConsumerId,
                db.DebtShare ?? throw new InvalidOperationException("DebtShare is null")
            );
    }

    extension (Consumer domain)
    {
        public ExpensesConsumer ToDb(Guid expenseId)
            => new()
            {
                ExpenseId = expenseId,
                ConsumerId = domain.UserId,
                DebtShare = domain.Share
            };
    }
}
