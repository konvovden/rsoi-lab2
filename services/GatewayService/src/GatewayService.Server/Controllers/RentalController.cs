using System.ComponentModel.DataAnnotations;
using GatewayService.Dto.Rental;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GatewayService.Server.Controllers;

[ApiController]
public class RentalController : ControllerBase
{
    /// <summary>
    /// Получить информацию о всех арендах пользователя
    /// </summary>
    /// <param name="xUserName">Имя пользователя</param>
    /// <response code="200">Информация обо всех арендах</response>
    [HttpGet]
    [Route("/api/v1/rental")]
    [SwaggerOperation("ApiV1RentalGet")]
    [SwaggerResponse(statusCode: 200, type: typeof(List<RentalResponse>), description: "Информация обо всех арендах")]
    public virtual IActionResult ApiV1RentalGet([FromHeader][Required()]string xUserName)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Забронировать автомобиль
    /// </summary>
    /// <param name="xUserName">Имя пользователя</param>
    /// <param name="createRentalRequest"></param>
    /// <response code="200">Информация о бронировании авто</response>
    /// <response code="400">Ошибка валидации данных</response>
    [HttpPost]
    [Route("/api/v1/rental")]
    [SwaggerOperation("ApiV1RentalPost")]
    [SwaggerResponse(statusCode: 200, type: typeof(CreateRentalResponse), description: "Информация о бронировании авто")]
    [SwaggerResponse(statusCode: 400, description: "Ошибка валидации данных")]
    public virtual IActionResult ApiV1RentalPost([FromHeader][Required()]string xUserName, [FromBody]CreateRentalRequest createRentalRequest)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Отмена аренды автомобиля
    /// </summary>
    /// <param name="rentalUid">UUID аренды</param>
    /// <param name="xUserName">Имя пользователя</param>
    /// <response code="204">Аренда успешно отменена</response>
    /// <response code="404">Аренда не найдена</response>
    [HttpDelete]
    [Route("/api/v1/rental/{rentalUid}")]
    [SwaggerOperation("ApiV1RentalRentalUidDelete")]
    [SwaggerResponse(statusCode: 404, description: "Аренда не найдена")]
    public virtual IActionResult ApiV1RentalRentalUidDelete([FromRoute][Required]Guid rentalUid, [FromHeader][Required()]string xUserName)
    { 
        throw new NotImplementedException();
    }

    /// <summary>
    /// Завершение аренды автомобиля
    /// </summary>
    /// <param name="rentalUid">UUID аренды</param>
    /// <param name="xUserName">Имя пользователя</param>
    /// <response code="204">Аренда успешно завершена</response>
    /// <response code="404">Аренда не найдена</response>
    [HttpPost]
    [Route("/api/v1/rental/{rentalUid}/finish")]
    [SwaggerOperation("ApiV1RentalRentalUidFinishPost")]
    [SwaggerResponse(statusCode: 404, description: "Аренда не найдена")]
    public virtual IActionResult ApiV1RentalRentalUidFinishPost([FromRoute][Required]Guid rentalUid, [FromHeader][Required()]string xUserName)
    { 
        throw new NotImplementedException();
    }

    /// <summary>
    /// Информация по конкретной аренде пользователя
    /// </summary>
    /// <param name="rentalUid">UUID аренды</param>
    /// <param name="xUserName">Имя пользователя</param>
    /// <response code="200">Информация по конкретному бронированию</response>
    /// <response code="404">Билет не найден</response>
    [HttpGet]
    [Route("/api/v1/rental/{rentalUid}")]
    [SwaggerOperation("ApiV1RentalRentalUidGet")]
    [SwaggerResponse(statusCode: 200, type: typeof(RentalResponse), description: "Информация по конкретному бронированию")]
    [SwaggerResponse(statusCode: 404, description: "Билет не найден")]
    public virtual IActionResult ApiV1RentalRentalUidGet([FromRoute][Required]Guid rentalUid, [FromHeader][Required()]string xUserName)
    {
        throw new NotImplementedException();
    }
}