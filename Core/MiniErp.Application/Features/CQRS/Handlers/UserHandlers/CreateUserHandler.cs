using MiniErp.Application.Features.CQRS.Commands.UserCommands;
using MiniErp.Application.Repositories.User;
using MiniErp.Domain.Entities;

namespace MiniErp.Application.Features.CQRS.Handlers.UserHandlers;

public class CreateUserHandler(IUserWriteRepository repository)
{
    public async Task Handle(CreateUserCommand command)
    {
        await repository.AddAsync(new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Username = command.Username,
            Password = command.Password,
            PhoneNumber = command.PhoneNumber,
            ProfilePicture = command.ProfilePicture
        });
        await repository.SaveAsync();

    }
}