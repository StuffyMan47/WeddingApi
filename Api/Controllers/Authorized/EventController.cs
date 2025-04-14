using Application.UseCase.Event.CreateEvent;
using Application.UseCase.Event.CreateEvent.Models;
using Application.UseCase.Event.DeleteEvent;
using Application.UseCase.Event.GetEvent;
using Application.UseCase.Event.GetEventList;
using Application.UseCase.Event.GetEventList.Models;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Controllers.Base;
using WeddingApi.Models;

namespace Wedding.Controllers.Authorized;

public class EventController : BaseAuthController
{
    /// <summary>
    /// Создать событие
    /// </summary>
    /// <returns></returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(ApiResponseModel), 200)]
    public async Task<IActionResult> AddEvent([FromServices] CreateEventUseCase useCase, CreateEventRequest request)
    {
        var result = await useCase.CreateEvent(request);
        return FromResult(result);
    }

    /// <summary>
    /// Получить список доступных событий
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    [ProducesResponseType(typeof(BaseApiResponseModel<List<GetEventListResponse>>), 200)]
    public async Task<IActionResult> GetEventsList([FromServices] GetEventListUseCase useCase)
    {
        var result = await useCase.GetEventList();
        return FromResult(result);
    }

    /// <summary>
    /// Получить информацию по конкретному событию
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(BaseApiResponseModel<GetEventListResponse>), 200)]
    public async Task<IActionResult> GetEvent([FromServices] GetEventUseCase useCase, long id)
    {
        var result = await useCase.GetEvent(id);
        return FromResult(result);
    }

    /// <summary>
    /// Удалить событие
    /// </summary>
    /// <returns></returns>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(typeof(BaseApiResponseModel<GetEventListResponse>), 200)]
    public async Task<IActionResult> DeleteEvent([FromServices] DeleteEventUseCase useCase, long id)
    {
        var result = await useCase.DeleteEvent(id);
        return FromResult(result);
    }

    //[HttpGet("get-photo")]
    //[ProducesResponseType(typeof(BaseApiResponseModel<FileStreamResult>), 200)]
    //public async Task<IActionResult> GetPhoto(long EventId)
    //{
    //    var image = await Mediator.Send(new GetPhotoQuery(EventId));
    //    var result = File(image, "image/jpeg");
    //    return result;
    //}

    //[HttpPost("questionnaire")]
    //[ProducesResponseType(typeof(BaseApiResponseModel<Result>), 200)]
    //public async Task<IActionResult> Questionnaire(QuestionnaireCommand request)
    //{
    //    var result = await Mediator.Send(request);
    //    return FromResult(result);
    //}

    //[HttpGet("get-schedule-list")]
    //[ProducesResponseType(typeof(BaseApiResponseModel<List<ScheduleDto>>), 200)]
    //public async Task<IActionResult> ScheduleList(long eventId)
    //{
    //    var result = await Mediator.Send(new GetScheduleListQuery(eventId));
    //    return FromResult(result);
    //}
}
