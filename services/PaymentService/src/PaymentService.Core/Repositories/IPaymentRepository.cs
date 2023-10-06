using PaymentService.Core.Models;
using PaymentService.Core.Models.Enums;

namespace PaymentService.Core.Repositories;

public interface IPaymentRepository
{
    Task<Payment> GetPaymentAsync(Guid id);
    Task<List<Payment>> GetPaymentsAsync(List<Guid> ids);

    Task<Payment> CreatePaymentAsync(Guid id,
        PaymentStatus status,
        int price);

    Task<Payment> SetPaymentStatusAsync(Guid id, PaymentStatus status);
}