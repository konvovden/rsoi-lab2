using System.ComponentModel.DataAnnotations;
using GatewayService.Dto.Cars;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GatewayService.Server.Controllers;

[ApiController]
public class CarsController : ControllerBase
{
    /// <summary>
    /// Получить список всех доступных для бронирования автомобилей
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <param name="showAll"></param>
    /// <response code="200">Список доступных для бронирования автомобилей</response>
    [HttpGet]
    [Route("/api/v1/cars")]
    [SwaggerOperation("ApiV1CarsGet")]
    [SwaggerResponse(statusCode: 200, type: typeof(CarsList), description: "Список доступных для бронирования автомобилей")]
    public IActionResult GetCars([FromQuery]int? page, [FromQuery][Range(1, 100)]int? size, [FromQuery]bool? showAll)
    {
        throw new NotImplementedException();
    }
}