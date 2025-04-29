using Application.Enums;
using Application.Errors;
using Application.Extensions.ActionResult;
using Application.Interfaces;
using Application.Permissions;
using Application.UseCase.User.CreateUser.Interfaces;
using Application.UseCase.User.CreateUser.Models;
using Application.UserContext;

namespace Application.UseCase.User.CreateUser;

public class CreateUserUseCase(
    ICreateUserStorage storage,
    IPasswordService passwordService,
    IUserContextProvider userProvider)
{
    public async Task<Result<Guid>> CreateUser(CreateUserRequest request, SystemRole role = SystemRole.Couple)
    {
        bool isLoginTaken = await storage.IsLoginAlreadyTaken(request.Login);
        if (isLoginTaken)
            return ErrorProvider.Users.LoginAlreadyTaken(request.Login).As<Guid>();

        var userContext = userProvider.GetUserContext();

        (string? passwordHash, string? passwordSalt) = passwordService.GeneratePasswordData(request.Password);

        var user = new UserCreateModel
        {
            Login = request.Login,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            SystemRole = role,
            UserClaims = role == SystemRole.Admin ? GetFullHubClaims() : [],
        };

        var result = await storage.SaveUser(user);
        return Result<Guid>.Success(result);
    }

    private static List<UserClaimCreateModel> GetFullHubClaims()
    {
        var result = new List<UserClaimCreateModel>();
        
        result.AddRange(StoreWebPermissions.FullAccess
            .Select(x => x.Name)
            .Select(permission => new UserClaimCreateModel
            {
                Claim = permission,
            }));

        return result;
    }
}