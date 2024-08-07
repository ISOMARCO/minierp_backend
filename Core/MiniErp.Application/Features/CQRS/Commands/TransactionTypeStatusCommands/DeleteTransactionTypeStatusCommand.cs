namespace MiniErp.Application.Features.CQRS.Commands.TransactionTypeStatusCommands;

public class DeleteTransactionTypeStatusCommand(string id)
{
    public string Id { get; set; } = id;
}