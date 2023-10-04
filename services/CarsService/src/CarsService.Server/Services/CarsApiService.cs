using CarsService.Api;
using CarsService.Core.Repositories;
using CarsService.Server.Converters;
using Grpc.Core;

namespace CarsService.Server.Services;

public class CarsApiService : Api.CarsService.CarsServiceBase
{
    private readonly ICarsRepository _carsRepository;

    public CarsApiService(ICarsRepository carsRepository)
    {
        _carsRepository = carsRepository;
    }

    public override async Task<GetCarsResponse> GetCars(GetCarsRequest request, ServerCallContext context)
    {
        var totalAmount = await _carsRepository.GetCarsAmountAsync();

        var offset = (request.Page - 1) * request.Size;

        var cars = await _carsRepository.GetCarsAsync(offset, request.Size);

        return new GetCarsResponse()
        {
            Page = request.Page,
            Size = request.Size,
            TotalAmount = totalAmount,
            Cars = { cars.ConvertAll(CarConverter.Convert) }
        };
    }
}