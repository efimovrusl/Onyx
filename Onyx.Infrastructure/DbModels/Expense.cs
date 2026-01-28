using System;
using System.Collections.Generic;

namespace Onyx.Infrastructure.DbModels;

public partial class Expense
{
    public Guid Id { get; set; }

    public Guid? GroupId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<ExpensesConsumer> ExpensesConsumers { get; set; } = new List<ExpensesConsumer>();

    public virtual ICollection<ExpensesPayer> ExpensesPayers { get; set; } = new List<ExpensesPayer>();

    public virtual Group? Group { get; set; }
}
