using Microsoft.EntityFrameworkCore;
using RentalService.Core.Models;
using RentalService.Core.Models.Enums;
using RentalService.Core.Repositories;
using RentalService.Database.Context;
using RentalService.Database.Repositories.Converters;
using RentalService.Database.Repositories.Converters.Enums;
using DbRental = RentalService.Database.Models.Rental;

namespace RentalService.Database.Repositories;

public class RentalRepository : IRentalRepository
{
    private readonly RentalServiceContext _dbContext;

    public RentalRepository(RentalServiceContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Rental> GetRentalAsync(Guid id)
    {
        var rental = await _dbContext.Rentals
            .AsNoTracking()
            .FirstAsync(r => r.Id == id);

        return RentalConverter.Convert(rental);
    }

    public async Task<List<Rental>> GetUserRentalsAsync(string username)
    {
        var rentals = await _dbContext.Rentals
            .Where(r => r.Username == username)
            .AsNoTracking()
            .ToListAsync();

        return rentals.ConvertAll(RentalConverter.Convert);
    }

    public async Task<Rental> CreateRentalAsync(Guid id, 
        string username,
        Guid paymentId,
        Guid carId,
        DateOnly dateFrom,
        DateOnly dateTo,
        RentalStatus status)
    {
        var dbRental = new DbRental(id,
            username,
            paymentId,
            carId,
            dateFrom,
            dateTo,
            RentalStatusConverter.Convert(status));

        await _dbContext.Rentals.AddAsync(dbRental);
        await _dbContext.SaveChangesAsync();

        return RentalConverter.Convert(dbRental);
    }

    public async Task<Rental> FinishRentalAsync(Guid id)
    {
        var rental = await _dbContext.Rentals
            .FirstAsync(r => r.Id == id);

        rental.Status = Models.Enums.RentalStatus.Finished;

        await _dbContext.SaveChangesAsync();

        return RentalConverter.Convert(rental);
    }

    public async Task<Rental> CancelRentalAsync(Guid id)
    {
        var rental = await _dbContext.Rentals
            .FirstAsync(r => r.Id == id);

        rental.Status = Models.Enums.RentalStatus.Canceled;

        await _dbContext.SaveChangesAsync();

        return RentalConverter.Convert(rental);
    }
}