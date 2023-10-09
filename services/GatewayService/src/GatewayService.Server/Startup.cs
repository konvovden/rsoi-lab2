using Microsoft.OpenApi.Models;

namespace GatewayService.Server;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson();
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "GatewayService.Server", Version = "v1" });
        });
        services.AddSwaggerGenNewtonsoftSupport();

        services.AddGrpcClient<CarsService.Api.CarsService.CarsServiceClient>(o =>
        {
            o.Address = new Uri("http://127.0.0.1:8071");
        });

        services.AddGrpcClient<PaymentService.Api.PaymentService.PaymentServiceClient>(o =>
        {
            o.Address = new Uri("http://127.0.0.1:8051");
        });

        services.AddGrpcClient<RentalService.Api.RentalService.RentalServiceClient>(o =>
        {
            o.Address = new Uri("http://127.0.0.1:8061");
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonService.Server v1"));
        
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}