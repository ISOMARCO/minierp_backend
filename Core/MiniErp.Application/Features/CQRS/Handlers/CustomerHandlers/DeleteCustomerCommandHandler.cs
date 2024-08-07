using MiniErp.Application.Features.CQRS.Commands.CustomerCommands;
using MiniErp.Application.Repositories.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniErp.Application.Features.CQRS.Handlers.CustomerHandlers
{
    public class DeleteCustomerCommandHandler(ICustomerWriteRepository writeRepository, ICustomerReadRepository readRepository)
    {
        public async Task Handle(string id)
        {
            var customer = await readRepository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            await writeRepository.RemoveAsync(id);
            await writeRepository.SaveAsync();
        }
    }
}
