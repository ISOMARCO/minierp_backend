using MiniErp.Application.Features.CQRS.Commands.ProductCommands;
using MiniErp.Application.Repositories.Product;
using MiniErp.Domain.Entities;

namespace MiniErp.Application.Features.CQRS.Handlers.ProductHandlers;

public class CreateProductCommandHandler(
    IProductWriteRepository writeRepository
)
{
    public async Task Handle(CreateProductCommand command)
    {
        var product = new Product
        {
            Name = command.Name,
            Type = command.Type,
            Note = command.Note
        };
        await writeRepository.AddAsync(product);
        await writeRepository.SaveAsync();
    }
}