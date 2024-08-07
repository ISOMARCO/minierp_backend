namespace MiniErp.Application.Features.CQRS.Commands.TransactionTypeStatusCommands;

public class UpdateTransactionTypeStatusCommand
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public bool InUse { get; set; } = false;
    public string? Note { get; set; }
}