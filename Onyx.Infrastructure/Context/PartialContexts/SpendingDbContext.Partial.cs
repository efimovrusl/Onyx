using Microsoft.EntityFrameworkCore;
using Onyx.Infrastructure.DbModels;

// ReSharper disable once CheckNamespace
namespace Onyx.Infrastructure.Context;

public partial class SpendingDbContext
{
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Expense>(entity => entity
                .Property(e => e.Currency)
                .HasColumnName("currency")
                .HasColumnType("currency_type"))
            .Entity<ExpensesPayer>(entity => entity
                .Property(e => e.Currency)
                .HasColumnName("currency")
                .HasColumnType("currency_type"));
    }
}