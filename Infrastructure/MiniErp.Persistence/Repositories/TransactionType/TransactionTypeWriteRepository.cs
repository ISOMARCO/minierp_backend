using MiniErp.Application.Repositories;
using MiniErp.Application.Repositories.TransactionType;
using MiniErp.Domain.Entities;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.TransactionType;

public class TransactionTypeWriteRepository(MiniErpDbContext context) : WriteRepository<TransactionTypes>(context), ITransactionTypeWriteRepository;