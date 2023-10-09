using System.Runtime.Serialization;
using GatewayService.Dto.Cars;
using GatewayService.Dto.Payments;
using GatewayService.Dto.Rental.Enums;

namespace GatewayService.Dto.Rental;

[DataContract]
public class Rental
{
    /// <summary>
    /// UUID аренды
    /// </summary>
    /// <value>UUID аренды</value>
    [DataMember(Name="rentalUid")]
    public string Id { get; set; }

    /// <summary>
    /// Статус аренды
    /// </summary>
    /// <value>Статус аренды</value>
    [DataMember(Name="status")]
    public RentalStatus Status { get; set; }

    /// <summary>
    /// Дата начала аренды
    /// </summary>
    /// <value>Дата начала аренды</value>
    [DataMember(Name="dateFrom")]
    public DateOnly DateFrom { get; set; }

    /// <summary>
    /// Дата окончания аренды
    /// </summary>
    /// <value>Дата окончания аренды</value>
    [DataMember(Name="dateTo")]
    public DateOnly DateTo { get; set; }

    /// <summary>
    /// Gets or Sets Car
    /// </summary>
    [DataMember(Name="car")]
    public Car Car { get; set; }

    /// <summary>
    /// Gets or Sets Payment
    /// </summary>
    [DataMember(Name="payment")]
    public Payment Payment { get; set; }

    public Rental(string id, 
        RentalStatus status,
        DateOnly dateFrom,
        DateOnly dateTo,
        Car car,
        Payment payment)
    {
        Id = id;
        Status = status;
        DateFrom = dateFrom;
        DateTo = dateTo;
        Car = car;
        Payment = payment;
    }
}