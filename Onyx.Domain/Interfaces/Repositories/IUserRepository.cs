using Onyx.Domain.Models;

namespace Onyx.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> GetById(Guid id);
    Task<User> GetByEmail(string email);
    Task<User> GetByUsername(string username);
    
    Task Insert(User user, string hashedPassword);
    Task Update(User user);
    Task Delete(Guid id);
}