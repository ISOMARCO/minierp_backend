using System.ComponentModel.DataAnnotations;
using MiniErp.Domain.Entities.Common;

namespace MiniErp.Domain.Entities;

public class TransactionTypeStatuses : BaseEntity
{
    [MaxLength(30)]
    public required string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public bool InUse { get; set; } = false;
    [MaxLength(200)]
    public string? Note { get; set; }
}