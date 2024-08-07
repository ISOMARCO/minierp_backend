using System.ComponentModel.DataAnnotations;
using MiniErp.Domain.Entities.Common;

namespace MiniErp.Domain.Entities;

public class Transactions : BaseEntity
{
    [MaxLength(7)]
    public required int TransactionNumber { get; set; }
    public required Guid Product { get; set; }
    public required Guid TransactionType { get; set; }
    public required Guid Source { get; set; }
    public Guid? Destination { get; set; }
    public required TransactionTypes TransactionTypes { get; set; }
    public string? Parameters { get; set; }
    public bool Open { get; set; } = false;
    public required DateTime TransactionDate { get; set; }
    [MaxLength(255)]
    public string? Note { get; set; }
}