using System;
using System.Collections.Generic;

namespace Onyx.Infrastructure.DbModels;

public partial class ExpensesPayer
{
    public Guid ExpenseId { get; set; }

    public Guid PayerId { get; set; }

    public decimal Amount { get; set; }

    public virtual Expense Expense { get; set; } = null!;

    public virtual User Payer { get; set; } = null!;
}
