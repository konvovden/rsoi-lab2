using RentalService.Core.Models;
using RentalService.Core.Models.Enums;

namespace RentalService.Core.Repositories;

public interface IRentalRepository
{
    Task<Rental> GetRentalAsync(Guid id);
    Task<List<Rental>> GetUserRentalsAsync(string username);

    Task<Rental> CreateRentalAsync(Guid id,
        string username,
        Guid paymentId,
        Guid carId,
        DateOnly dateFrom,
        DateOnly dateTo,
        RentalStatus status);

    Task<Rental> FinishRentalAsync(Guid id);
    Task<Rental> CancelRentalAsync(Guid id);
}