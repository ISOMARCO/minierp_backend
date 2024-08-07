using MiniErp.Application.Features.CQRS.Commands.WarehouseCommands;
using MiniErp.Application.Repositories.Warehouse;

namespace MiniErp.Application.Features.CQRS.Handlers.WarehouseHandlers;

public class UpdateWarehouseCommandHandler(
    IWarehouseReadRepository readRepository, 
    IWarehouseWriteRepository writeRepository)
{
    public async Task Handle(UpdateWarehouseCommand command) 
    {
        var warehouse = await readRepository.GetByIdAsync(command.Id);
        if (warehouse == null)
        {
            throw new Exception("Warehouse not found");
        }

        if (command.Name == null)
        {
            throw new Exception("Name is required");
        }
        warehouse.Name = command.Name;
        warehouse.IsActive = command.IsActive;
        warehouse.InUse = command.InUse;
        writeRepository.Update(warehouse);
        await writeRepository.SaveAsync();
    }
}