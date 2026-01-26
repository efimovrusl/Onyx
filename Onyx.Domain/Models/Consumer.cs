namespace Onyx.Domain.Models;

public record Consumer
(
    Guid UserId, 
    decimal Share = 1
);
