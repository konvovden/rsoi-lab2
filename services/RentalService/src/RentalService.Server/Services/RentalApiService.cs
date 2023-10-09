using Grpc.Core;
using RentalService.Api;
using RentalService.Core.Repositories;
using RentalService.Server.Converters;
using RentalStatus = RentalService.Core.Models.Enums.RentalStatus;

namespace RentalService.Server.Services;

public class RentalApiService : Api.RentalService.RentalServiceBase
{
    private readonly IRentalRepository _rentalRepository;

    public RentalApiService(IRentalRepository rentalRepository)
    {
        _rentalRepository = rentalRepository;
    }

    public override async Task<GetUserRentalResponse> GetUserRental(GetUserRentalRequest request, ServerCallContext context)
    {
        var rentalId = Guid.Parse(request.RentalId);

        var rental = await _rentalRepository.GetRentalAsync(rentalId);

        return new GetUserRentalResponse()
        {
            Rental = RentalConverter.Convert(rental)
        };
    }

    public override async Task<GetUserRentalsResponse> GetUserRentals(GetUserRentalsRequest request, ServerCallContext context)
    {
        var rentals = await _rentalRepository.GetUserRentalsAsync(request.Username);

        return new GetUserRentalsResponse()
        {
            Rentals = { rentals.ConvertAll(RentalConverter.Convert) }
        };
    }

    public override async Task<CreateRentalResponse> CreateRental(CreateRentalRequest request, ServerCallContext context)
    {
        var rental = await _rentalRepository.CreateRentalAsync(Guid.NewGuid(),
            request.Username,
            Guid.Parse(request.PaymentId),
            Guid.Parse(request.CarId),
            DateConverter.Convert(request.DateFrom),
            DateConverter.Convert(request.DateTo),
            RentalStatus.InProgress);

        return new CreateRentalResponse()
        {
            Rental = RentalConverter.Convert(rental)
        };
    }

    public override async Task<FinishRentalResponse> FinishRental(FinishRentalRequest request, ServerCallContext context)
    {
        var rental = await _rentalRepository.FinishRentalAsync(Guid.Parse(request.RentalId));

        return new FinishRentalResponse()
        {
            Rental = RentalConverter.Convert(rental)
        };
    }

    public override async Task<CancelRentalResponse> CancelRental(CancelRentalRequest request, ServerCallContext context)
    {
        var rental = await _rentalRepository.CancelRentalAsync(Guid.Parse(request.RentalId));

        return new CancelRentalResponse()
        {
            Rental = RentalConverter.Convert(rental)
        };
    }
}