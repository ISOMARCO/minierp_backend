namespace MiniErp.Application.Features.CQRS.Commands.WarehouseCommands;

public class UpdateWarehouseCommand
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public bool InUse { get; set; } = false;
}