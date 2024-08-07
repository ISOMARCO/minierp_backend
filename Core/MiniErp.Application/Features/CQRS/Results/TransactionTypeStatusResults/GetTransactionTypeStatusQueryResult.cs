namespace MiniErp.Application.Features.CQRS.Results.TransactionTypeStatusResults;

public class GetTransactionTypeStatusQueryResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public bool InUse { get; set; } = false;
    public string? Note { get; set; }
}