using Microsoft.EntityFrameworkCore;
using Onyx.Domain.Interfaces.Repositories;
using Onyx.Domain.Models;
using Onyx.Infrastructure.Context;
using Onyx.Infrastructure.Mappers;

namespace Onyx.Infrastructure.Repositories;

public class GroupRepository(SpendingDbContext db) : IGroupRepository
{
    public async Task<Group> GetById(Guid id)
    {
        var dbGroup = await db.Groups
                          .FirstOrDefaultAsync(g => g.Id == id)
                      ?? throw new Exception($"Group {id} not found.");

        return dbGroup.ToDomain();
    }

    public async Task<List<Group>> GetByUser(Guid userId)
    {
        var dbGroups = await db.GroupsUsers
            .Where(gu => gu.UserId == userId)
            .Select(gu => gu.Group)
            .ToListAsync();

        return [.. dbGroups.Select(gu => gu.ToDomain())];
    }

    public async Task<List<User>> GetMembers(Guid groupId)
    {
        var dbUsers = await db.GroupsUsers
            .Where(gu => gu.GroupId == groupId)
            .Select(gu => gu.User)
            .ToListAsync();

        return [.. dbUsers.Select(static u => u.ToDomain())];
    }

    public async Task Insert(Group group, List<Guid> memberIds)
    {
        var dbGroup = new DbModels.Group
        {
            Id = group.Id,
            Name = group.Name
        };

        db.Groups.Add(dbGroup);

        var dbMemberships = memberIds.Select(userId => new DbModels.GroupsUser
        {
            GroupId = group.Id,
            UserId = userId
        }).ToList();

        db.GroupsUsers.AddRange(dbMemberships);

        await db.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        // TODO: Implement group deletion properly, like by only marking it as deleted
        // await db.Groups
        //     .Where(g => g.Id == id)
        //     .ExecuteDeleteAsync();
        throw new NotImplementedException();
    }

    public async Task AddMember(Guid groupId, Guid userId)
    {
        db.GroupsUsers.Add(new DbModels.GroupsUser
        {
            GroupId = groupId,
            UserId = userId
        });

        await db.SaveChangesAsync();
    }

    public async Task RemoveMember(Guid groupId, Guid userId)
    {
        await db.GroupsUsers
            .Where(gu => gu.GroupId == groupId && gu.UserId == userId)
            .ExecuteDeleteAsync();
    }
}