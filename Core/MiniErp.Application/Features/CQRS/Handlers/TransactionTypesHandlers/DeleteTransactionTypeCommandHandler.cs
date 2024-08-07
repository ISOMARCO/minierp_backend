using MiniErp.Application.Features.CQRS.Commands.TransactionTypeCommands;
using MiniErp.Application.Repositories.TransactionType;

namespace MiniErp.Application.Features.CQRS.Handlers.TransactionTypesHandlers;

public class DeleteTransactionTypeCommandHandler(
    ITransactionTypeReadRepository readRepository,
    ITransactionTypeWriteRepository writeRepository
    )
{
    public async Task Handle(DeleteTransactionTypeCommand command)
    {
        var transactionType = await readRepository.GetByIdAsync(command.Id);
        if (transactionType == null)
        {
            throw new Exception("Transaction Type not found");
        }

        await writeRepository.RemoveAsync(command.Id);
        await writeRepository.SaveAsync();
    }
}