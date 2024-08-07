namespace MiniErp.Application.Features.CQRS.Commands.CustomerCommands;

public class CreateCustomerCommand
{
    public string FullName { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? TIN { get; set; }
    public string? Email { get; set; }
}