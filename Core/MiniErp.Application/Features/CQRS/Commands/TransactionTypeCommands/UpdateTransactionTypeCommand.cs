using Newtonsoft.Json;

namespace MiniErp.Application.Features.CQRS.Commands.TransactionTypeCommands;

public class UpdateTransactionTypeCommand
{
    private string? _parameters = null;
    public required string Id { get; set; }
    public required string Name { get; set; }
    public bool IsPositive { get; set; } = true;
    public string? SourceParameter { get; set; }
    public string? DestinationParameter { get; set; }
    public bool IsActive { get; set; } = true;
    public Guid? SourceToDestinationStatus { get; set; }
    public Guid? DestinationToSourceStatus { get; set; }

    public string? Parameters
    {
        get => _parameters;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                _parameters = null;
            }
            else
            {
                var parametersList = value.Split(',').Select(p => p.Trim()).ToList();
                _parameters = JsonConvert.SerializeObject(parametersList);
            }
        }
    }
}