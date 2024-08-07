using System.ComponentModel.DataAnnotations;
using MiniErp.Domain.Entities.Common;

namespace MiniErp.Domain.Entities;

public class Warehouse : BaseEntity
{
    [MaxLength(30)]
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public bool InUse { get; set; } = false;
}