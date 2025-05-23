using Application.Errors;
using Application.Extensions.ActionResult;
using Application.Interfaces;
using Application.UseCase.User.GenerateToken;
using Application.UseCase.User.Login.Interfaces;
using Application.UseCase.User.Login.Models;

namespace Application.UseCase.User.Login;

public class LoginUseCase(GenerateTokenUseCase tokenGenerator, ILoginStorage storage, IPasswordService passwordService)
{
    public async Task<Result<LoginResponse>> Login(LoginRequest request)
    {
        var user = await storage.GetUser(request.Login);

        if (user == null)
            return ErrorProvider.Auth.InvalidLoginOrPassword.As<LoginResponse>();

        bool isPasswordValid = passwordService.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);
        if (!isPasswordValid)
            return ErrorProvider.Auth.InvalidLoginOrPassword.As<LoginResponse>();

        var token = await tokenGenerator.GenerateToken(new()
        {
            UserId = user.UserId,
            SystemRole = user.SystemRole,
            Login = user.Login
        });

        return token.IsFailure
            ? token.As<LoginResponse>()
            : Result<LoginResponse>.Success(new(token.Value.AccessToken, token.Value.RefreshToken));
    }
}