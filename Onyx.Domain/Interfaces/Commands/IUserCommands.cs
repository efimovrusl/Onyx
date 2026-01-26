using Onyx.Domain.Models;

namespace Onyx.Domain.Interfaces.Commands;

public interface IUserCommands
{
    Task<User> CreateUser(string email, string username, string firstName, string lastName, string password);
    Task UpdateUser(Guid userId, string firstName, string lastName);
    Task DeleteUser(Guid userId);
}