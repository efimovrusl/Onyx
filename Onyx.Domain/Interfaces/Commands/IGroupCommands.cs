using Onyx.Domain.Models;

namespace Onyx.Domain.Interfaces.Commands;

public interface IGroupCommands
{
    Task<Group> CreateGroup(string name, List<Guid> memberIds);
    Task AddUserToGroup(Guid groupId, Guid userId);
    Task RemoveUserFromGroup(Guid groupId, Guid userId);
    Task DeleteGroup(Guid groupId);
}