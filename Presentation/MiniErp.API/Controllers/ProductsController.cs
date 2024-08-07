using System.Net;
using Microsoft.AspNetCore.Mvc;
using MiniErp.Application.Features.CQRS.Commands.ProductCommands;
using MiniErp.Application.Features.CQRS.Handlers.ProductHandlers;
using MiniErp.Application.Features.CQRS.Queries.ProductQueries;
using MiniErp.Application.Filters.Product;
using MiniErp.Application.RequestParameters;

namespace MiniErp.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class ProductsController(
    GetProductQueryHandler getProductQueryHandler,
    GetProductWithFilterQueryHandler getProductWithFilterQueryHandler,
    GetProductByIdQueryHandler getProductByIdQueryHandler,
    CreateProductCommandHandler createProductCommandHandler,
    UpdateProductCommandHandler updateProductCommandHandler,
    DeleteProductCommandHandler deleteProductCommandHandler
    ) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] Pagination pagination)
    {
        var products = await getProductQueryHandler.Handle(pagination.Page, pagination.Size);
        return Ok(products);
    }
    
    [HttpGet("filter")]
    public async Task<IActionResult> Get([FromQuery] ProductFilter filter)
    {
        var products = await getProductWithFilterQueryHandler.Handle(filter);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var product = await getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProductCommand command)
    {
        await createProductCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.Created,
            message = "Product created successfully"
        });
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(UpdateProductCommand command)
    {
        await updateProductCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.OK,
            message = "Product updated successfully"
        });
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteProductCommand command)
    {
        await deleteProductCommandHandler.Handle(command);
        return Ok(new
        {
            status = HttpStatusCode.OK,
            message = "Product deleted successfully"
        });
    }
}