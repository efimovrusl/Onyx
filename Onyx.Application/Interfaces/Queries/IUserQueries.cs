using Onyx.Domain.Models;

namespace Onyx.Application.Interfaces.Queries;

public interface IUserQueries
{
    Task<User> GetUserById(Guid id);
    Task<User> GetUserByEmail(string email);
    Task<User> GetUserByUsername(string username);
}