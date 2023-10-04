using CarsService.Api;
using GatewayService.Clients.CarsServiceApiClient.Configuration;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;

namespace GatewayService.Clients.CarsServiceApiClient;

public class CarsServiceApiClient : ICarsServiceApiClient
{
    private readonly CarsService.Api.CarsService.CarsServiceClient _client;

    public CarsServiceApiClient(IOptions<CarsServiceApiClientConfiguration> configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration.Value.Address);
        _client = new CarsService.Api.CarsService.CarsServiceClient(channel);
    }

    public async Task<GetCarsResponse> GetCarsAsync(GetCarsRequest request)
    {
        var response = await _client.GetCarsAsync(request);

        return response;
    }
}