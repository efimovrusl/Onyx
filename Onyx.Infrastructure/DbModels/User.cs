using System;
using System.Collections.Generic;

namespace Onyx.Infrastructure.DbModels;

public partial class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<ExpensesConsumer> ExpensesConsumers { get; set; } = new List<ExpensesConsumer>();

    public virtual ICollection<ExpensesPayer> ExpensesPayers { get; set; } = new List<ExpensesPayer>();

    public virtual LoginSecret? LoginSecret { get; set; }
}
