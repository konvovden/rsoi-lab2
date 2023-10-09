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

    public async Task<Car> GetCarAsync(Guid id)
    {
        var car = await _dbContext.Cars
            .AsNoTracking()
            .FirstAsync(c => c.Id == id);

        return CarConverter.Convert(car);
    }

    public Task<int> GetCarsAmountAsync()
    {
        return _dbContext.Cars.CountAsync();
    }

    public async Task<List<Car>> GetCarsAsync(int offset, int limit, bool onlyAvailable)
    {
        var query = _dbContext.Cars
            .AsQueryable();

        if (onlyAvailable)
            query = query.Where(c => c.Availability == true);
                
        var cars = await query
            .OrderBy(c => c.Id)
            .Skip(offset)
            .Take(limit)
            .AsNoTracking()
            .ToListAsync();

        return cars.ConvertAll(CarConverter.Convert);
    }

    public async Task<List<Car>> GetCarsByIdsAsync(List<Guid> ids)
    {
        var cars = await _dbContext.Cars
            .Where(c => ids.Contains(c.Id))
            .AsNoTracking()
            .ToListAsync();

        return cars.ConvertAll(CarConverter.Convert);
    }

    public async Task<Car> SetCarAvailabilityAsync(Guid id, bool availability)
    {
        var car = await _dbContext.Cars
            .FirstAsync(c => c.Id == id);

        car.Availability = availability;

        await _dbContext.SaveChangesAsync();

        return CarConverter.Convert(car);
    }
}