using CarsService.Api;
using Grpc.Core;

namespace CarsService.Server.Services;

public class CarsApiService : Api.CarsService.CarsServiceBase
{
    public override Task<GetCarsResponse> GetCars(GetCarsRequest request, ServerCallContext context)
    {
        return base.GetCars(request, context);
    }
}