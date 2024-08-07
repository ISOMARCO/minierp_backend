using MiniErp.Application.Features.CQRS.Commands.TransactionTypeStatusCommands;
using MiniErp.Application.Repositories.TransactionTypeStatus;

namespace MiniErp.Application.Features.CQRS.Handlers.TransactionTypeStatusHandlers;

public class DeleteTransactionTypeStatusCommandHandler(
    ITransactionTypeStatusReadRepository readRepository,
    ITransactionTypeStatusWriteRepository writeRepository
    )
{
    public async Task Handle(DeleteTransactionTypeStatusCommand command)
    {
        var transactionTypeStatus = await readRepository.GetByIdAsync(command.Id);
        if (transactionTypeStatus == null)
        {
            throw new Exception("Transaction Type Status not found");
        }

        await writeRepository.RemoveAsync(command.Id);
        await writeRepository.SaveAsync();
    }
}