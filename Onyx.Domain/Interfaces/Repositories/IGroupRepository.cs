using Onyx.Domain.Models;

namespace Onyx.Domain.Interfaces.Repositories;

public interface IGroupRepository
{
    Task<Group> GetById(Guid id);
    Task<List<Group>> GetByUser(Guid userId);
    Task<List<User>> GetMembers(Guid groupId);
    
    Task Insert(Group group, List<Guid> memberIds);
    Task Delete(Guid id);
    Task AddMember(Guid groupId, Guid userId);
    Task RemoveMember(Guid groupId, Guid userId);
}