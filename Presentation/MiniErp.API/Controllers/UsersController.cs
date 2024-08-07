using System.Net;
using Microsoft.AspNetCore.Mvc;
using MiniErp.Application.Features.CQRS.Commands.UserCommands;
using MiniErp.Application.Features.CQRS.Handlers.UserHandlers;
using MiniErp.Application.Filters.User;
using MiniErp.Application.Repositories.User;
using MiniErp.Application.RequestParameters;

namespace MiniErp.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class UsersController(
    IUserReadRepository userReadRepository,
    IUserWriteRepository userWriteRepository,
    CreateUserHandler createUserHandler,
    UpdateUserHandler updateUserHandler,
    GetUserWithFilterQueryHandler getUserWithFilterQueryHandler
    ) : Controller
{
    [HttpGet]
    public IActionResult Get([FromQuery] Pagination pagination)
    {
        return Ok(userReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateUserCommand command)
    {
        await createUserHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.Created,
            message = "User created successfully"
        });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await userWriteRepository.RemoveAsync(id);
        await userWriteRepository.SaveAsync();
        return StatusCode((int)HttpStatusCode.NoContent);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(UpdateUserCommand command)
    {
        try
        {
            await updateUserHandler.Handle(command);
        }catch(Exception e)
        {
            return BadRequest(new
            {
                status = HttpStatusCode.BadRequest,
                message = e.Message
            });
        }
        return Ok(new
        {
            status = HttpStatusCode.OK,
            message = "User updated successfully"
        });
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetByFilter([FromQuery] UserFilter filter)
    {
        var users = await getUserWithFilterQueryHandler.Handle(filter);
        return Ok(users);
    }
}