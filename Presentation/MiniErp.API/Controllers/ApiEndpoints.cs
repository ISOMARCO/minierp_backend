using Microsoft.AspNetCore.Mvc;
using MiniErp.Application.Features.CQRS.Handlers.ApiEndpointHandlers;

namespace MiniErp.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class ApiEndpoints(
    GetApiEndpointQueryHandler getApiEndpointQueryHandler,
    GetApiEndpointByCodeQueryHandler getApiEndpointByCodeQueryHandler
    ) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await getApiEndpointQueryHandler.Handle());
    }

    [HttpGet("{codes}")]
    public async Task<IActionResult> Get(string codes)
    {
        var codesArray = codes.Split(",");
        return Ok(await getApiEndpointByCodeQueryHandler.Handle(codesArray));
    }
}