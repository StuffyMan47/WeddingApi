using Application.UseCase.User.CreateUser;
using Application.UseCase.User.CreateUser.Models;
using Application.UseCase.User.Login;
using Application.UseCase.User.Login.Models;
using Application.UseCase.User.RefreshToken;
using Application.UseCase.User.RefreshToken.Models;
using Bar.Controllers.Base;
using Bar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bar.Controllers.Anonymous;

public class AuthController : BaseController
{
        
    /// <summary>
    /// Получить токены для доступа к апи
    /// </summary>
    /// <response code="200">Аутентификация прошла успешно</response>
    /// <returns></returns>
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BaseApiResponseModel<LoginResponse>), 200)]
    public async Task<IActionResult> Login([FromServices] LoginUseCase useCase, [FromBody] LoginRequest request)
    {
        var result = await useCase.Login(request);
        return FromResult(result);
    }

    /// <summary>
    /// Обновить имеющийся токен
    /// </summary>
    /// <returns></returns>
    [HttpPost("refresh")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BaseApiResponseModel<RefreshTokenResponse>), 200)]
    public async Task<IActionResult> Refresh([FromServices] RefreshTokenUseCase useCase, [FromBody] RefreshTokenRequest request)
    {
        var result = await useCase.RefreshToken(request);
        return FromResult(result);
    }

    /// <summary>
    /// Создание юзера
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="createUserRequest"></param>
    /// <returns></returns>
    [HttpPost("create-user")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BaseApiResponseModel<Guid>), 200)]
    public async Task<IActionResult> CreateUser([FromServices] CreateUserUseCase useCase, [FromBody] CreateUserRequest createUserRequest)
    {
        var result = await useCase.CreateUser(createUserRequest);
        return FromResult(result);
    }
}