namespace Application.Interfaces;

public interface IPasswordService : ISingletonService
{
    (string passwordHash, string passwordSalt) GeneratePasswordData(string password);
    bool VerifyPassword(string password, string passwordHash, string passwordSalt);
}