namespace MiniErp.Application.Features.CQRS.Commands.UserCommands;

public class UpdateUserCommand
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfilePicture { get; set; }
}