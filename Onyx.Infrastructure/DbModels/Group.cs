using System;
using System.Collections.Generic;

namespace Onyx.Infrastructure.DbModels;

public partial class Group
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
