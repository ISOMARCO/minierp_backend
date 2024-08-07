using System.Net;
using Microsoft.AspNetCore.Mvc;
using MiniErp.Application.Features.CQRS.Commands.TransactionTypeStatusCommands;
using MiniErp.Application.Features.CQRS.Handlers.TransactionTypeStatusHandlers;
using MiniErp.Application.RequestParameters;

namespace MiniErp.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class TransactionTypeStatusesController(
    GetTransactionTypeStatusQueryHandler getTransactionTypeStatusQueryHandler,
    CreateTransactionTypeStatusCommandHandler createTransactionTypeStatusCommandHandler,
    UpdateTransactionTypeStatusCommandHandler updateTransactionTypeStatusCommandHandler,
    DeleteTransactionTypeStatusCommandHandler removeTransactionTypeStatusCommandHandler
    ) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] Pagination pagination)
    {
        var result = await getTransactionTypeStatusQueryHandler.Handle(pagination.Page, pagination.Size);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateTransactionTypeStatusCommand command)
    {
        await createTransactionTypeStatusCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.Created,
            message = "Transaction type status created successfully"
        });
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(UpdateTransactionTypeStatusCommand command)
    {
        await updateTransactionTypeStatusCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.OK,
            message = "Transaction type status updated successfully"
        });
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteTransactionTypeStatusCommand command)
    {
        await removeTransactionTypeStatusCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.OK,
            message = "Transaction type status removed successfully"
        });
    }
}