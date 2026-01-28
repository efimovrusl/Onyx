using System;
using System.Collections.Generic;

namespace Onyx.Infrastructure.DbModels;

public partial class ExpensesConsumer
{
    public Guid ExpenseId { get; set; }

    public Guid ConsumerId { get; set; }

    public double? DebtShare { get; set; }

    public virtual User Consumer { get; set; } = null!;

    public virtual Expense Expense { get; set; } = null!;
}
