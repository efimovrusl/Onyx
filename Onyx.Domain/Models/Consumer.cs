namespace Onyx.Domain.Models;

public record Consumer
(
    Guid UserId, 
    double Share = 1
);
