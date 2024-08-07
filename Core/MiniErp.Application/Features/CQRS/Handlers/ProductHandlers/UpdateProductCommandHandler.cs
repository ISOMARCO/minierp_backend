using MiniErp.Application.Features.CQRS.Commands.ProductCommands;
using MiniErp.Application.Repositories.Product;

namespace MiniErp.Application.Features.CQRS.Handlers.ProductHandlers;

public class UpdateProductCommandHandler(
    IProductReadRepository readRepository,
    IProductWriteRepository writeRepository
    )
{
    public async Task Handle(UpdateProductCommand command)
    {
        var product = await readRepository.GetByIdAsync(command.Id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        product.Name = command.Name;
        product.Type = command.Type;
        product.Note = command.Note;
        writeRepository.Update(product);
        await writeRepository.SaveAsync();
    }
}