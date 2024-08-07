using System.Net;
using Microsoft.AspNetCore.Mvc;
using MiniErp.Application.Features.CQRS.Commands.CustomerCommands;
using MiniErp.Application.Features.CQRS.Handlers.CustomerHandlers;
using MiniErp.Application.Filters.Customer;
using MiniErp.Application.RequestParameters;

namespace MiniErp.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class CustomersController(
    GetCustomerQueryHandler getCustomerQueryHandler,
    CreateCustomerCommandHandler createCustomerCommandHandler,
    UpdateCustomerCommandHandler updateCustomerCommandHandler,
    GetCustomerWithFilterQueryHandler getCustomerWithFilterQueryHandler,
    DeleteCustomerCommandHandler deleteCustomerCommandHandler
    ) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] Pagination pagination)
    {
        return Ok(await getCustomerQueryHandler.Handle(pagination.Page, pagination.Size));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand command)
    {
        await createCustomerCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.Created,
            message = "Customer created successfully"
        });
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateCustomerCommand command)
    {
        await updateCustomerCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.OK,
            message = "Customer updated successfully"
        });
    }
    
    [HttpGet("filter")]
    public async Task<IActionResult> GetByFilter([FromQuery] CustomerFilter filter)
    {
        return Ok(await getCustomerWithFilterQueryHandler.Handle(filter));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await deleteCustomerCommandHandler.Handle(id);
        return Ok(new
        {
            status = HttpStatusCode.OK,
            message = "Customer deleted successfully"
        });
    }
}