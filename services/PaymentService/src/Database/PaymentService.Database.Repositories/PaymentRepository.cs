using Microsoft.EntityFrameworkCore;
using PaymentService.Core.Models;
using PaymentService.Core.Models.Enums;
using PaymentService.Core.Repositories;
using PaymentService.Database.Context;
using PaymentService.Database.Repositories.Converters;
using PaymentService.Database.Repositories.Converters.Enums;
using DbPayment = PaymentService.Database.Models.Payment;

namespace PaymentService.Database.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly PaymentServiceContext _dbContext;

    public PaymentRepository(PaymentServiceContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Payment> GetPaymentAsync(Guid id)
    {
        var payment = await _dbContext.Payments
            .AsNoTracking()
            .FirstAsync(p => p.Id == id);

        return PaymentConverter.Convert(payment);
    }

    public async Task<List<Payment>> GetPaymentsAsync(List<Guid> ids)
    {
        var payments = await _dbContext.Payments
            .Where(p => ids.Contains(p.Id))
            .AsNoTracking()
            .ToListAsync();

        return payments.ConvertAll(PaymentConverter.Convert);
    }

    public async Task<Payment> CreatePaymentAsync(Guid id, PaymentStatus status, int price)
    {
        var payment = new DbPayment(id, PaymentStatusConverter.Convert(status), price);

        await _dbContext.Payments.AddAsync(payment);
        await _dbContext.SaveChangesAsync();

        return PaymentConverter.Convert(payment);
    }

    public async Task<Payment> SetPaymentStatusAsync(Guid id, PaymentStatus status)
    {
        var payment = await _dbContext.Payments
            .FirstAsync(p => p.Id == id);

        payment.Status = PaymentStatusConverter.Convert(status);

        return PaymentConverter.Convert(payment);
    }
}