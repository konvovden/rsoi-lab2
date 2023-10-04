﻿using GatewayService.Converters.Cars.Enums;
using DtoCar = GatewayService.Dto.Cars.Car;
using ApiCar = CarsService.Api.Car;

namespace GatewayService.Converters.Cars;

public static class CarConverter
{
    public static DtoCar Convert(ApiCar apiCar)
    {
        return new DtoCar(Guid.Parse(apiCar.Id),
            apiCar.Brand,
            apiCar.Model,
            apiCar.RegistrationNumber,
            apiCar.Power,
            CarTypeConverter.Convert(apiCar.Type),
            apiCar.Price,
            apiCar.Availability);
    }
}