using Onyx.Domain.Models;

namespace Onyx.Application.Interfaces.Queries;

public interface IGroupQueries
{
    Task<Group> GetGroupById(Guid groupId);
    Task<List<Group>> GetUserGroups(Guid userId);
    Task<List<User>> GetGroupMembers(Guid groupId);
}