using Onyx.Domain.Interfaces.Commands;
using Onyx.Domain.Interfaces.Repositories;
using Onyx.Domain.Models;

namespace Onyx.Application.Commands;

public class GroupCommands(
    IGroupRepository groupRepository
) : IGroupCommands
{
    public async Task<Group> CreateGroup(string name, List<Guid> memberIds)
    {
        var newGroup = new Group(Guid.CreateVersion7(), name);
        await groupRepository.Insert(newGroup, memberIds);
        return newGroup;
    }

    public async Task AddUserToGroup(Guid groupId, Guid userId)
    {
        await groupRepository.AddMember(groupId, userId);
    }

    public async Task RemoveUserFromGroup(Guid groupId, Guid userId)
    {
        await groupRepository.RemoveMember(groupId, userId);
    }

    public async Task DeleteGroup(Guid groupId)
    {
        await groupRepository.Delete(groupId);
    }
}