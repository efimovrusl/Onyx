using Onyx.Domain.Enums;

namespace Onyx.Domain.Models;

public record Expense
(
    Guid Id,
    Guid? GroupId,
    string Description,
    decimal Amount,
    Currency Currency,
    DateTime CreatedAt,
    List<Payer> Payers,
    List<Consumer> Consumers
);
