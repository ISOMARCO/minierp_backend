using MiniErp.Application.Features.CQRS.Commands.TransactionTypeStatusCommands;
using MiniErp.Application.Repositories.TransactionTypeStatus;
using MiniErp.Domain.Entities;

namespace MiniErp.Application.Features.CQRS.Handlers.TransactionTypeStatusHandlers;

public class CreateTransactionTypeStatusCommandHandler(ITransactionTypeStatusWriteRepository writeRepository)
{
    public async Task Handle(CreateTransactionTypeStatusCommand command)
    {
        await writeRepository.AddAsync(new TransactionTypeStatuses()
        {
            Name = command.Name,
            IsActive = command.IsActive,
            InUse = command.InUse,
            Note = command.Note
        });
        await writeRepository.SaveAsync();
    }
}