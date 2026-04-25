using Onyx.Domain.Models;

namespace Onyx.Domain.Interfaces.Commands;

public interface IGroupCommands
{
    [Obsolete("Not implemented yet")]
    Task<Group> CreateGroup(string name, List<Guid> memberIds);
    [Obsolete("Not implemented yet")]
    Task AddUserToGroup(Guid groupId, Guid userId);
    [Obsolete("Not implemented yet")]
    Task RemoveUserFromGroup(Guid groupId, Guid userId);
    [Obsolete("Not implemented yet")]
    Task DeleteGroup(Guid groupId);
}