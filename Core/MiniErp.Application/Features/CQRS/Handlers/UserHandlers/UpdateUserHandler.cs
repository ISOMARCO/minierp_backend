using MiniErp.Application.Features.CQRS.Commands.UserCommands;
using MiniErp.Application.Repositories.User;

namespace MiniErp.Application.Features.CQRS.Handlers.UserHandlers;

public class UpdateUserHandler(IUserReadRepository readRepository, IUserWriteRepository writeRepository)
{
    public async Task Handle(UpdateUserCommand command)
    {
        var user = await readRepository.GetByIdAsync(command.Id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        user.FirstName = command.FirstName;
        user.LastName = command.LastName;
        user.Email = command.Email;
        user.Username = command.Username;
        user.Password = command.Password;
        user.PhoneNumber = command.PhoneNumber;
        user.ProfilePicture = command.ProfilePicture;

        writeRepository.Update(user);
        await writeRepository.SaveAsync();
    }
}