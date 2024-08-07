using System.ComponentModel.DataAnnotations;
using MiniErp.Domain.Entities.Common;
using MiniErp.Domain.Entities.Parameters;

namespace MiniErp.Domain.Entities;

public class TransactionTypes : BaseEntity
{
    [MaxLength(30)]
    public required string Name { get; set; }
    public bool IsPositive { get; set; } = true;
    public Guid? SourceParameter { get; set; }
    public ApiEndpoints? ApiEndpointSource { get; set; }
    public Guid? DestinationParameter { get; set; }
    public ApiEndpoints? ApiEndpointDestination { get; set; }
    public Guid? SourceToDestinationStatus { get; set; }
    public TransactionTypeStatuses? TransactionTypeStatusesSource { get; set; }
    public Guid? DestinationToSourceStatus { get; set; }
    public TransactionTypeStatuses? TransactionTypeStatusesDestination { get; set; }
    public string? Parameters { get; set; }
    public bool InUse { get; set; } = false;
    public bool IsActive { get; set; } = true;
}