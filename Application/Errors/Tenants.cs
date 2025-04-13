using Application.Extensions.ActionResult;

namespace Application.Errors;

public static partial class ErrorProvider
{
    public static class Tenants
    {
        public static Result NotFound(int id) => Result.Invalid()
            .WithMessage("Организация не найдена")
            .WithError($"Id: {id}");

        public static Result NoAgentAssigned(int id) => Result.Invalid()
            .WithMessage("Тенанту не назначен агент")
            .WithError($"Id: {id}");
    }
}