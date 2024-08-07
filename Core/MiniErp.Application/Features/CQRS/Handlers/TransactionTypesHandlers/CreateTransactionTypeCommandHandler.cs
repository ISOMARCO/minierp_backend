using MiniErp.Application.Features.CQRS.Commands.TransactionTypeCommands;
using MiniErp.Application.Repositories.TransactionType;
using MiniErp.Domain.Entities;

namespace MiniErp.Application.Features.CQRS.Handlers.TransactionTypesHandlers;

public class CreateTransactionTypeCommandHandler(
    ITransactionTypeWriteRepository transactionTypeWriteRepository
    )
{
    public async Task Handle(CreateTransactionTypeCommand command)
    {
        var transactionType = new TransactionTypes
        {
            Name = command.Name,
            IsPositive = command.IsPositive,
            SourceParameter = string.IsNullOrEmpty(command.SourceParameter) ? (Guid?)null : Guid.Parse(command.SourceParameter),
            DestinationParameter = string.IsNullOrEmpty(command.DestinationParameter) ? (Guid?)null : Guid.Parse(command.DestinationParameter),
            InUse = command.InUse,
            IsActive = command.IsActive
        };
        await transactionTypeWriteRepository.AddAsync(transactionType);
        await transactionTypeWriteRepository.SaveAsync();
    }
}