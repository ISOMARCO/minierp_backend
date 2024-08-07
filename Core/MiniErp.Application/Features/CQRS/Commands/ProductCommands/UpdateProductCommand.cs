namespace MiniErp.Application.Features.CQRS.Commands.ProductCommands;

public class UpdateProductCommand
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Type { get; set; }
    public string? Note { get; set; }
}