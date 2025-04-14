using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Models;

namespace WeddingApi.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
[Authorize]
[ApiExplorerSettings(GroupName = AuthorizedGroupName)]
[ProducesResponseType(typeof(ApiResponseModel), 401)]
[ProducesResponseType(typeof(ApiResponseModel), 403)]
public class BaseAuthController : BaseController
{
    public const string AuthorizedGroupName = "authorized";
}