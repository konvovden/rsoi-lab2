using Grpc.Core;
using PaymentService.Api;
using PaymentService.Core.Repositories;
using PaymentService.Server.Converters;
using PaymentStatus = PaymentService.Core.Models.Enums.PaymentStatus;

namespace PaymentService.Server.Services;

public class PaymentApiService : Api.PaymentService.PaymentServiceBase
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentApiService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public override async Task<GetPaymentResponse> GetPayment(GetPaymentRequest request, ServerCallContext context)
    {
        var paymentId = Guid.Parse(request.Id);

        var payment = await _paymentRepository.GetPaymentAsync(paymentId);

        return new GetPaymentResponse()
        {
            Payment = PaymentConverter.Convert(payment)
        };
    }

    public override async Task<GetPaymentsResponse> GetPayments(GetPaymentsRequest request, ServerCallContext context)
    {
        var paymentIds = request.Ids
            .Select(Guid.Parse)
            .ToList();

        var payments = await _paymentRepository.GetPaymentsAsync(paymentIds);

        var notFoundPayments = paymentIds
            .Except(payments.Select(p => p.Id))
            .Select(id => id.ToString());

        return new GetPaymentsResponse()
        {
            Payments = {payments.ConvertAll(PaymentConverter.Convert)},
            NotFoundIds = {notFoundPayments}
        };
    }

    public override async Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest request, ServerCallContext context)
    {
        var payment = await _paymentRepository.CreatePaymentAsync(Guid.NewGuid(),
            PaymentStatus.Paid,
            request.Price);

        return new CreatePaymentResponse()
        {
            Payment = PaymentConverter.Convert(payment)
        };
    }

    public override async Task<CancelPaymentResponse> CancelPayment(CancelPaymentRequest request, ServerCallContext context)
    {
        var paymentId = Guid.Parse(request.Id);

        var payment = await _paymentRepository.SetPaymentStatusAsync(paymentId, PaymentStatus.Canceled);

        return new CancelPaymentResponse()
        {
            Payment = PaymentConverter.Convert(payment)
        };
    }
}