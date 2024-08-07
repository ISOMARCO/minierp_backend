using System.Net;
using Microsoft.AspNetCore.Mvc;
using MiniErp.Application.Features.CQRS.Commands.WarehouseCommands;
using MiniErp.Application.Features.CQRS.Handlers.WarehouseHandlers;
using MiniErp.Application.RequestParameters;

namespace MiniErp.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class WarehousesController(
    GetWarehouseQueryHandler getWarehouseQueryHandler,
    CreateWarehouseCommandHandler createWarehouseCommandHandler,
    UpdateWarehouseCommandHandler updateWarehouseCommandHandler,
    DeleteWarehouseCommandHandler deleteWarehouseCommandHandler
    ) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] Pagination pagination)
    {
        var result = await getWarehouseQueryHandler.Handle(pagination.Page, pagination.Size);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateWarehouseCommand command)
    {
        await createWarehouseCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.Created,
            message = "Warehouse created successfully"
        });
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateWarehouseCommand command)
    {
        await updateWarehouseCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.OK,
            message = "Warehouse updated successfully"
        });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteWarehouseCommand command)
    {
        await deleteWarehouseCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.OK,
            message = "Warehouse deleted successfully"
        });
    }
}