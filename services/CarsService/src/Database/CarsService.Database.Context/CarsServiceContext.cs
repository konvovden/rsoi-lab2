using CarsService.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsService.Database.Context;

#nullable disable
public class CarsServiceContext : DbContext
{
    public DbSet<Car> Cars { get; set; }

    public CarsServiceContext()
    {
        
    }

    public CarsServiceContext(DbContextOptions options) : base(options)  
    {
        
    }
}
#nullable restore