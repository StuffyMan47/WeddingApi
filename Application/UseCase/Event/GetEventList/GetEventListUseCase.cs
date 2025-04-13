using Application.Extensions.ActionResult;
using Application.UseCase.Event.GetEventList.Interfaces;
using Application.UseCase.Event.GetEventList.Models;
using Application.UserContext;

namespace Application.UseCase.Event.GetEventList;

public class GetEventListUseCase(IGetEventListStorage storage, IUserContextProvider userProvider)
{
    public async Task<Result<List<GetEventListResponse>>> GetEventList()
    {
        var currentUser = userProvider.GetUserContext();

        var filter = new GetEventListFilter();
        if (currentUser.SystemRole == Enums.SystemRole.Couple)
        {
            filter.userId = currentUser.Id;
        }

        var result = await storage.GetEventLists(filter);

        return Result<List<GetEventListResponse>>.Success(result);
    }
}
