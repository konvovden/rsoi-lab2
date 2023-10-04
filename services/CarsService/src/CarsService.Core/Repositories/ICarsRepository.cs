using CarsService.Core.Models;

namespace CarsService.Core.Repositories;

public interface ICarsRepository
{
    Task<int> GetCarsAmountAsync();
    Task<List<Car>> GetCarsAsync(int offset, int limit);
}