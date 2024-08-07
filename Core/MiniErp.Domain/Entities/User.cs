using System.ComponentModel.DataAnnotations;
using MiniErp.Domain.Entities.Common;

namespace MiniErp.Domain.Entities;

public class User: BaseEntity
{
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string? LastName { get; set; }
    [MaxLength(30)]
    public string Username { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    [MaxLength(150)]
    public string Password { get; set; }
    [MaxLength(30)]
    public string? PhoneNumber { get; set; }
    [MaxLength(200)]
    public string? ProfilePicture { get; set; }
}