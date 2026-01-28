using Onyx.Domain.Enums;

// ReSharper disable once CheckNamespace
namespace Onyx.Infrastructure.DbModels;

public partial class Expense
{
    public Currency Currency { get; set; }
}