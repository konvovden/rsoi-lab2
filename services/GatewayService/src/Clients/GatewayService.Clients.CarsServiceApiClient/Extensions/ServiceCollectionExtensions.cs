using GatewayService.Clients.CarsServiceApiClient.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GatewayService.Clients.CarsServiceApiClient.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCarsServiceApiClient(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<CarsServiceApiClientConfiguration>(configuration
            .GetRequiredSection(nameof(CarsServiceApiClientConfiguration)));
        
        serviceCollection.AddSingleton<ICarsServiceApiClient, CarsServiceApiClient>();

        return serviceCollection;
    }
}