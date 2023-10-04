using System.ComponentModel.DataAnnotations;
using CarsService.Api;
using GatewayService.Clients.CarsServiceApiClient;
using GatewayService.Converters.Cars;
using GatewayService.Dto.Cars;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GatewayService.Server.Controllers;

[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarsServiceApiClient _carsServiceClient;

    public CarsController(ICarsServiceApiClient carsServiceClient)
    {
        _carsServiceClient = carsServiceClient;
    }

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
    public async Task<IActionResult> GetCars([FromQuery]int? page, [FromQuery][Range(1, 100)]int? size, [FromQuery]bool? showAll)
    {
        page ??= 1;
        size ??= 50;
        showAll ??= false;

        var request = new GetCarsRequest()
        {
            Page = page.Value,
            Size = size.Value,
            ShowAll = showAll.Value
        };

        var response = await _carsServiceClient.GetCarsAsync(request);

        return Ok(CarsListConverter.Convert(response));
    }
}