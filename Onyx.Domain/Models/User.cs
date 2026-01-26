namespace Onyx.Domain.Models;

public record User
(
    Guid Id,
    string Email,
    string Username,
    string FirstName,
    string LastName,
    DateTime CreationDate,
    bool IsDeleted
);