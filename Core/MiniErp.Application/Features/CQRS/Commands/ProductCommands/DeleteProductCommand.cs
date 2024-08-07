namespace MiniErp.Application.Features.CQRS.Commands.ProductCommands;

public class DeleteProductCommand(string id)
{
    public string Id { get; set; } = id;
}