using MiniErp.Application.Features.CQRS.Commands.TransactionTypeStatusCommands;
using MiniErp.Application.Repositories.TransactionTypeStatus;

namespace MiniErp.Application.Features.CQRS.Handlers.TransactionTypeStatusHandlers;

public class UpdateTransactionTypeStatusCommandHandler(
    ITransactionTypeStatusWriteRepository writeRepository,
    ITransactionTypeStatusReadRepository readRepository
    )
{
    public async Task Handle(UpdateTransactionTypeStatusCommand command)
    {
        var transactionTypeStatus = await readRepository.GetByIdAsync(command.Id);
        if (transactionTypeStatus == null)
        {
            throw new Exception("Transaction Type Status not found");
        }

        transactionTypeStatus.Name = command.Name;
        transactionTypeStatus.IsActive = command.IsActive;
        transactionTypeStatus.Note = command.Note;
        transactionTypeStatus.InUse = command.InUse;
        writeRepository.Update(transactionTypeStatus);
        await writeRepository.SaveAsync();
    }
}