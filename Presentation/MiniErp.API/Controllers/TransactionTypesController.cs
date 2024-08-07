using System.Net;
using Microsoft.AspNetCore.Mvc;
using MiniErp.Application.Features.CQRS.Commands.TransactionTypeCommands;
using MiniErp.Application.Features.CQRS.Handlers.TransactionTypesHandlers;
using MiniErp.Application.RequestParameters;

namespace MiniErp.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class TransactionTypesController(
    GetTransactionTypeQueryHandler getTransactionTypeQueryHandler,
    CreateTransactionTypeCommandHandler createTransactionTypeCommandHandler,
    UpdateTransactionTypeCommandHandler updateTransactionTypeCommandHandler,
    DeleteTransactionTypeCommandHandler deleteTransactionTypeCommandHandler
    ) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] Pagination pagination)
    {
        var result = await getTransactionTypeQueryHandler.Handle(pagination.Page, pagination.Size);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateTransactionTypeCommand command)
    {
        await createTransactionTypeCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.Created,
            message = "Transaction type created successfully"
        });
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateTransactionTypeCommand command)
    {
        await updateTransactionTypeCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.OK,
            message = "Transaction type updated successfully"
        });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteTransactionTypeCommand command)
    {
        await deleteTransactionTypeCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.OK,
            message = "Transaction type deleted successfully"
        });
    }
}