using CarsService.Core.Models;

namespace CarsService.Core.Repositories;

public interface ICarsRepository
{
    Task<Car> GetCarAsync(Guid id);
    Task<int> GetCarsAmountAsync();
    Task<List<Car>> GetCarsAsync(int offset, int limit, bool onlyAvailable);
    Task<List<Car>> GetCarsByIdsAsync(List<Guid> ids);
    Task<Car> SetCarAvailabilityAsync(Guid id, bool availability);
}