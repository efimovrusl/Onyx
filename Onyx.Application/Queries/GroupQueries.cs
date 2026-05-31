using Onyx.Application.Interfaces.Queries;
using Onyx.Application.Interfaces.Repositories;
using Onyx.Domain.Models;

namespace Onyx.Application.Queries;

public class GroupQueries(IGroupRepository groupRepository) : IGroupQueries
{
    public async Task<Group> GetGroupById(Guid groupId)
    {
        return await groupRepository.GetById(groupId);
    }

    public async Task<List<Group>> GetUserGroups(Guid userId)
    {
        return await groupRepository.GetByUser(userId);
    }

    public async Task<List<User>> GetGroupMembers(Guid groupId)
    {
        return await groupRepository.GetMembers(groupId);
    }
}