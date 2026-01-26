using Microsoft.AspNetCore.Mvc;
using Onyx.Domain.Interfaces.Commands;
using Onyx.Domain.Interfaces.Queries;
using Onyx.Domain.Models;

namespace Onyx.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(
    IUserQueries queries,
    IUserCommands commands
) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        var user = await queries.GetUserById(id);
        return Ok(user);
    }

    [HttpGet("email/{email}")]
    public async Task<ActionResult<User>> GetUserByEmail(string email)
    {
        var user = await queries.GetUserByEmail(email);
        return Ok(user);
    }

    [HttpGet("username/{username}")]
    public async Task<ActionResult<User>> GetUserByUsername(string username)
    {
        var user = await queries.GetUserByUsername(username);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserRequest request)
    {
        var user = await commands.CreateUser(
            request.Email,
            request.Username,
            request.FirstName,
            request.LastName,
            request.Password
        );
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserRequest request)
    {
        await commands.UpdateUser(id, request.FirstName, request.LastName);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await commands.DeleteUser(id);
        return Ok();
    }
}

public record CreateUserRequest(string Email, string Username, string FirstName, string LastName, string Password);
public record UpdateUserRequest(string FirstName, string LastName);