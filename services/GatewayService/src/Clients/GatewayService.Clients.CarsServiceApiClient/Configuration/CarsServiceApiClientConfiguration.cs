namespace GatewayService.Clients.CarsServiceApiClient.Configuration;

public class CarsServiceApiClientConfiguration
{
    public string Address { get; set; }

    public CarsServiceApiClientConfiguration()
    {
        Address = string.Empty;
    }
    
    public CarsServiceApiClientConfiguration(string address)
    {
        Address = address;
    }
}