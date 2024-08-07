using MiniErp.Application.Features.CQRS.Commands.WarehouseCommands;
using MiniErp.Application.Repositories.Warehouse;

namespace MiniErp.Application.Features.CQRS.Handlers.WarehouseHandlers;

public class DeleteWarehouseCommandHandler(
    IWarehouseReadRepository readRepository,
    IWarehouseWriteRepository writeRepository
    )
{
    public async Task Handle(DeleteWarehouseCommand command)
    {
        var warehouse = await readRepository.GetByIdAsync(command.Id);
        if (warehouse == null)
        {
            throw new Exception("Warehouse not found");
        }
        await writeRepository.RemoveAsync(command.Id);
        await writeRepository.SaveAsync();
    }
}