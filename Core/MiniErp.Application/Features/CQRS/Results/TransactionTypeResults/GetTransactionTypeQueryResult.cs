using MiniErp.Domain.Entities.Parameters;
using Newtonsoft.Json;

namespace MiniErp.Application.Features.CQRS.Results.TransactionTypeResults;

public class GetTransactionTypeQueryResult
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public bool IsPositive { get; set; } = true;
    public Guid? SourceParameter { get; set; }
    public Guid? DestinationParameter { get; set; }
    public bool InUse { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public Guid? SourceToDestinationStatus { get; set; }
    public Guid? DestinationToSourceStatus { get; set; }
    public string? Parameters { get; set; }
    public string ParametersAsText
    {
        get
        {
            if (string.IsNullOrEmpty(Parameters))
                return string.Empty;
            var parametersList = JsonConvert.DeserializeObject<List<string>>(Parameters);
            return string.Join(",", parametersList!);
        }
    }
}