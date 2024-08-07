using System.ComponentModel.DataAnnotations;
using MiniErp.Domain.Entities.Common;

namespace MiniErp.Domain.Entities;

public class Product : BaseEntity
{
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string? Type { get; set; }
    [MaxLength(200)]
    public string? Note { get; set; }
}