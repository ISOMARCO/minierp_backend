using System.ComponentModel.DataAnnotations;
using MiniErp.Domain.Entities.Common;

namespace MiniErp.Domain.Entities;

public class Customer : BaseEntity
{
    [MaxLength(70)]
    public string FullName { get; set; }
    [MaxLength(100)]
    public string? Address { get; set; }
    [MaxLength(30)]
    public string? PhoneNumber { get; set; }
    [MaxLength(20)]
    public string? TIN { get; set; }
    [MaxLength(100)]
    public string? Email { get; set; }
    [MaxLength(200)]
    public string? Note { get; set; }
}