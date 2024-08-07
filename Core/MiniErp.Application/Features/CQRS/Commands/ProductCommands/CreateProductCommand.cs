namespace MiniErp.Application.Features.CQRS.Commands.ProductCommands;

public class CreateProductCommand
{
    public string Name { get; set; }
    public string? Type { get; set; }
    public string? Note { get; set; }
}