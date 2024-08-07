using MiniErp.Application.Filters.User;

namespace MiniErp.Application.Features.CQRS.Queries.UserQueries;

public class GetUserWithFilterQuery
{
    public UserFilter? Filter { get; set; }
}