using MiniErp.Application.Features.CQRS.Commands.WarehouseCommands;
using MiniErp.Application.Repositories.Warehouse;
using MiniErp.Domain.Entities;

namespace MiniErp.Application.Features.CQRS.Handlers.WarehouseHandlers;

public class CreateWarehouseCommandHandler(IWarehouseWriteRepository writeRepository)
{
    public async Task Handle(CreateWarehouseCommand command)
    {
        if (command.Name == null)
        {
            throw new Exception("Name is required");
        }
        await writeRepository.AddAsync(new Warehouse
        {
            Name = command.Name,
            IsActive = command.IsActive,
            InUse = command.InUse
        });
        await writeRepository.SaveAsync();
    }
}