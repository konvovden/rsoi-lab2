using Microsoft.EntityFrameworkCore;
using PaymentService.Core.Repositories;
using PaymentService.Database.Context;
using PaymentService.Database.Repositories;
using PaymentService.Server.Services;

namespace PaymentService.Server;

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
        services.AddControllers();
        
        services.AddGrpc();
        
        services.AddDbContext<PaymentServiceContext>(opt => 
            opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPaymentRepository, PaymentRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGrpcService<PaymentApiService>();
        });
    }
}