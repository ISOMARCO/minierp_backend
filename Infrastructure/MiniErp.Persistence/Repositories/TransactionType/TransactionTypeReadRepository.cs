using MiniErp.Application.Repositories.TransactionType;
using MiniErp.Domain.Entities;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.TransactionType;

public class TransactionTypeReadRepository(MiniErpDbContext context) : ReadRepository<TransactionTypes>(context), ITransactionTypeReadRepository;