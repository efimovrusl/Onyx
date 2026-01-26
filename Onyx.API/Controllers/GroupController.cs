using Microsoft.AspNetCore.Mvc;
using Onyx.Domain.Interfaces.Commands;
using Onyx.Domain.Interfaces.Queries;
using Onyx.Domain.Models;

namespace Onyx.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController(
    IGroupQueries queries,
    IGroupCommands commands
) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<Group>> GetGroup(Guid id)
    {
        var group = await queries.GetGroupById(id);
        return Ok(group);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<Group>>> GetUserGroups(Guid userId)
    {
        var groups = await queries.GetUserGroups(userId);
        return Ok(groups);
    }

    [HttpGet("{groupId}/members")]
    public async Task<ActionResult<List<User>>> GetGroupMembers(Guid groupId)
    {
        var members = await queries.GetGroupMembers(groupId);
        return Ok(members);
    }

    [HttpPost]
    public async Task<ActionResult<Group>> CreateGroup([FromBody] CreateGroupRequest request)
    {
        var group = await commands.CreateGroup(request.Name, request.MemberIds);
        return Ok(group);
    }

    [HttpPost("{groupId}/members/{userId}")]
    public async Task<IActionResult> AddUserToGroup(Guid groupId, Guid userId)
    {
        await commands.AddUserToGroup(groupId, userId);
        return Ok();
    }

    [HttpDelete("{groupId}/members/{userId}")]
    public async Task<IActionResult> RemoveUserFromGroup(Guid groupId, Guid userId)
    {
        await commands.RemoveUserFromGroup(groupId, userId);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGroup(Guid id)
    {
        await commands.DeleteGroup(id);
        return Ok();
    }
}

public record CreateGroupRequest(string Name, List<Guid> MemberIds);