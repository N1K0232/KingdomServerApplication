using KingdomServerManager.BusinessLayer.Services;
using KingdomServerManager.Shared.Models;
using KingdomServerManager.Shared.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace KingdomServerManager.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    private readonly IUsersService usersService;

    public UsersController(IUsersService usersService)
    {
        this.usersService = usersService;
    }

    [HttpDelete("DeleteUser/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("not valid id");
        }

        await usersService.DeleteAsync(id);
        return Ok("user deleted");
    }

    [HttpDelete("DeleteUser/{userName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(string userName)
    {
        if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName))
        {
            return BadRequest("not valid username");
        }

        await usersService.DeleteAsync(userName);
        return Ok("user deleted");
    }

    [HttpGet("GetUser/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUser(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("not valid id");
        }

        var user = await usersService.GetAsync(id);

        return user != null ?
            Ok(user) :
            NotFound("user not found");
    }

    [HttpGet("GetUser/{userName}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUser(string userName)
    {
        if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName))
        {
            return BadRequest("not valid username");
        }

        var user = await usersService.GetAsync(userName);

        return user != null ?
            Ok(user) :
            NotFound("user not found");
    }

    [HttpPost("SaveUser")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SaveUser([FromBody] SaveUserRequest request)
    {
        var user = await usersService.SaveAsync(request);
        return Ok(user);
    }
}