using MiniErp.Application.Features.CQRS.Commands.TransactionTypeCommands;
using MiniErp.Application.Repositories.TransactionType;

namespace MiniErp.Application.Features.CQRS.Handlers.TransactionTypesHandlers;

public class UpdateTransactionTypeCommandHandler(
    ITransactionTypeReadRepository readRepository,
    ITransactionTypeWriteRepository writeRepository
    )
{
    public async Task Handle(UpdateTransactionTypeCommand command)
    {
        var transactionType = await readRepository.GetByIdAsync(command.Id);
        if (transactionType == null)
        {
            throw new Exception("Transaction Type not found");
        }

        transactionType.Name = command.Name;
        transactionType.IsPositive = command.IsPositive;
        transactionType.SourceParameter = string.IsNullOrEmpty(command.SourceParameter) ? (Guid?)null : Guid.Parse(command.SourceParameter);
        transactionType.DestinationParameter = string.IsNullOrEmpty(command.DestinationParameter) ? (Guid?)null : Guid.Parse(command.DestinationParameter);
        transactionType.IsActive = command.IsActive;
        transactionType.SourceToDestinationStatus = command.SourceToDestinationStatus;
        transactionType.DestinationToSourceStatus = command.DestinationToSourceStatus;
        transactionType.Parameters = command.Parameters;
        writeRepository.Update(transactionType);
        await writeRepository.SaveAsync();
    }
}