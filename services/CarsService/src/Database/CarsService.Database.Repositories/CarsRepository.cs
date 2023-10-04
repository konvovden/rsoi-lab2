using CarsService.Core.Models;
using CarsService.Core.Repositories;
using CarsService.Database.Context;
using CarsService.Database.Repositories.Converters;
using Microsoft.EntityFrameworkCore;

namespace CarsService.Database.Repositories;

public class CarsRepository : ICarsRepository
{
    private readonly CarsServiceContext _dbContext;

    public CarsRepository(CarsServiceContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> GetCarsAmountAsync()
    {
        return _dbContext.Cars.CountAsync();
    }

    public async Task<List<Car>> GetCarsAsync(int offset, int limit)
    {
        var cars = await _dbContext.Cars
            .OrderBy(c => c.Id)
            .Skip(offset)
            .Take(limit)
            .AsNoTracking()
            .ToListAsync();

        return cars.ConvertAll(CarConverter.Convert);
    }
}