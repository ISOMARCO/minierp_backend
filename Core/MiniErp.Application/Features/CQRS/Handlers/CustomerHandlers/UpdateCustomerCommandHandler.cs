using MiniErp.Application.Features.CQRS.Commands.CustomerCommands;
using MiniErp.Application.Repositories.Customer;

namespace MiniErp.Application.Features.CQRS.Handlers.CustomerHandlers;

public class UpdateCustomerCommandHandler(ICustomerReadRepository readRepository, ICustomerWriteRepository writeRepository)
{
    public async Task Handle(UpdateCustomerCommand command)
    {
        var customer = await readRepository.GetByIdAsync(command.Id);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        customer.FullName = command.FullName;
        customer.Address = command.Address;
        customer.PhoneNumber = command.PhoneNumber;
        customer.TIN = command.TIN;
        customer.Email = command.Email;
        writeRepository.Update(customer);
        await writeRepository.SaveAsync();
    }
}