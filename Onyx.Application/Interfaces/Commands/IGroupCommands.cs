using Onyx.Domain.Models;

namespace Onyx.Application.Interfaces.Commands;

public interface IGroupCommands
{
    Task<Group> CreateGroup(string name, List<Guid> memberIds);
    Task AddUserToGroup(Guid groupId, Guid userId);
    Task RemoveUserFromGroup(Guid groupId, Guid userId);
    [Obsolete("Not implemented yet")]
    Task DeleteGroup(Guid groupId);
}