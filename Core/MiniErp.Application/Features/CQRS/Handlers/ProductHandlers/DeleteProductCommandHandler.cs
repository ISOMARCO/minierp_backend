using MiniErp.Application.Features.CQRS.Commands.ProductCommands;
using MiniErp.Application.Repositories.Product;

namespace MiniErp.Application.Features.CQRS.Handlers.ProductHandlers;

public class DeleteProductCommandHandler(
    IProductWriteRepository productWriteRepository,
    IProductReadRepository productReadRepository
    )
{
    public async Task Handle(DeleteProductCommand command)
    {
        var product = await productReadRepository.GetByIdAsync(command.Id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        
        await productWriteRepository.RemoveAsync(command.Id);
        await productWriteRepository.SaveAsync();
    }
}