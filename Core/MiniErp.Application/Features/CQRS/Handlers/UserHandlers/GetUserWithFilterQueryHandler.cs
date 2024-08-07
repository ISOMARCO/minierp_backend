using MiniErp.Application.Features.CQRS.Results.UserResults;
using MiniErp.Application.Filters.User;
using MiniErp.Application.Repositories.User;

namespace MiniErp.Application.Features.CQRS.Handlers.UserHandlers;

public class GetUserWithFilterQueryHandler(
    IUserReadRepository repository
    )
{
    public async Task<List<GetUserWithFilterQueryResult>> Handle(UserFilter filter)
    {
        var users = await repository.GetUsersByFilterAsync(filter);
        return users.Select(user => new GetUserWithFilterQueryResult
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            ProfilePicture = user.ProfilePicture
        }).ToList();
    }
}