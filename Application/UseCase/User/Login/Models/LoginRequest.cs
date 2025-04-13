namespace Application.UseCase.User.Login.Models;

public record struct LoginRequest(string Login, string Password);

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Login).NotEmpty().WithName("Имя пользователя");
        RuleFor(x => x.Password).NotEmpty().WithName("Пароль");
    }
}