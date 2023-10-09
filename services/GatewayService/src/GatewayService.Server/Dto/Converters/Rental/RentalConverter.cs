using GatewayService.Converters;
using GatewayService.Server.Dto.Converters.Cars;
using GatewayService.Server.Dto.Converters.Payment;
using GatewayService.Server.Dto.Converters.Rental.Enums;
using ApiRental = RentalService.Api.Rental;
using DtoRental = GatewayService.Dto.Rental.Rental;
using ApiCar = CarsService.Api.Car;
using ApiPayment = PaymentService.Api.Payment;

namespace GatewayService.Server.Dto.Converters.Rental;

public static class RentalConverter
{
    public static DtoRental Convert(ApiRental apiRental, ApiCar apiCar, ApiPayment apiPayment)
    {
        return new DtoRental(apiRental.Id,
            RentalStatusConverter.Convert(apiRental.Status),
            DateConverter.Convert(apiRental.DateFrom),
            DateConverter.Convert(apiRental.DateTo),
            CarConverter.Convert(apiCar),
            PaymentConverter.Convert(apiPayment));
    }
}