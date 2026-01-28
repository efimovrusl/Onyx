using System;
using System.Collections.Generic;
using Onyx.Domain.Enums;

// ReSharper disable once CheckNamespace
namespace Onyx.Infrastructure.DbModels;

public partial class ExpensesPayer
{
    public Currency Currency { get; set; }
}
