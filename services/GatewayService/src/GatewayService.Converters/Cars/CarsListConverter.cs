using CarsService.Api;
using GatewayService.Dto.Cars;

namespace GatewayService.Converters.Cars;

public static class CarsListConverter
{
    public static CarsList Convert(GetCarsResponse getCarsResponse)
    {
        return new CarsList(getCarsResponse.Page,
            getCarsResponse.Size,
            getCarsResponse.TotalAmount,
            getCarsResponse.Cars.ToList().ConvertAll(CarConverter.Convert));
    }
}