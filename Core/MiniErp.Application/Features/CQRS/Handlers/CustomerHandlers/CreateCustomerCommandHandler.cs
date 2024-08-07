using MiniErp.Application.Features.CQRS.Commands.CustomerCommands;
using MiniErp.Application.Repositories.Customer;
using MiniErp.Domain.Entities;

namespace MiniErp.Application.Features.CQRS.Handlers.CustomerHandlers;

public class CreateCustomerCommandHandler(ICustomerWriteRepository writeRepository)
{
    public async Task Handle(CreateCustomerCommand command)
    {
        await writeRepository.AddAsync(new Customer
        {
            FullName = command.FullName,
            Address = command.Address,
            PhoneNumber = command.PhoneNumber,
            TIN = command.TIN,
            Email = command.Email
        });
        await writeRepository.SaveAsync();
    }
}