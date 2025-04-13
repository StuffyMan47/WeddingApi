using Application.Extensions.ActionResult;
using Application.UseCase.Place.GetPlacesList.Interfaces;
using Application.UseCase.Place.GetPlacesList.Models;
using Application.UserContext;

namespace Application.UseCase.Place.GetPlacesList;

public class GetPlacesListUseCase(IGetPlacesListStorage storage, IUserContextProvider userProvider)
{
    public async Task<Result<List<GetPlacesListResponse>>> GetPlacesList()
    {
        var currentUser = userProvider.GetUserContext();

        var filter = new GetPlaceListFilter();
        if (currentUser.SystemRole == Enums.SystemRole.Couple)
        {
            filter.userId = currentUser.Id;
        }

        var result = await storage.GetPlacesList(filter);
        return Result<List<GetPlacesListResponse>>.Success(result);
    }
}

