using Onyx.Domain.Enums;

namespace Onyx.Domain.Models;

public record Payer
(
    Guid UserId, 
    decimal Amount,
    Currency Currency
);
