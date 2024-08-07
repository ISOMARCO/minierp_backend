namespace MiniErp.Application.Features.CQRS.Commands.TransactionTypeCommands;

public class CreateTransactionTypeCommand
{
    public string Name { get; set; }
    public bool IsPositive { get; set; } = true;
    public string? SourceParameter { get; set; }
    public string? DestinationParameter { get; set; }
    public bool InUse { get; set; } = false;
    public bool IsActive { get; set; } = true;
}