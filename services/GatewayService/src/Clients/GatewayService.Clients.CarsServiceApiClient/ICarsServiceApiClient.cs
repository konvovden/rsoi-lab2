using CarsService.Api;

namespace GatewayService.Clients.CarsServiceApiClient;

public interface ICarsServiceApiClient
{
    Task<GetCarsResponse> GetCarsAsync(GetCarsRequest request);
}