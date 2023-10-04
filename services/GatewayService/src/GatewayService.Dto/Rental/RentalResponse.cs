using System.Runtime.Serialization;
using GatewayService.Dto.Cars;
using GatewayService.Dto.Payments;
using GatewayService.Dto.Rental.Enums;

namespace GatewayService.Dto.Rental;

[DataContract]
public class RentalResponse
{
    /// <summary>
    /// UUID аренды
    /// </summary>
    /// <value>UUID аренды</value>
    [DataMember(Name="rentalUid", EmitDefaultValue=false)]
    public Guid RentalUid { get; set; }

    /// <summary>
    /// Статус аренды
    /// </summary>
    /// <value>Статус аренды</value>
    [DataMember(Name="status", EmitDefaultValue=false)]
    public RentalStatus Status { get; set; }

    /// <summary>
    /// Дата начала аренды
    /// </summary>
    /// <value>Дата начала аренды</value>
    [DataMember(Name="dateFrom", EmitDefaultValue=false)]
    public string DateFrom { get; set; }

    /// <summary>
    /// Дата окончания аренды
    /// </summary>
    /// <value>Дата окончания аренды</value>
    [DataMember(Name="dateTo", EmitDefaultValue=false)]
    public string DateTo { get; set; }

    /// <summary>
    /// Gets or Sets Car
    /// </summary>
    [DataMember(Name="car", EmitDefaultValue=false)]
    public Car Car { get; set; }

    /// <summary>
    /// Gets or Sets Payment
    /// </summary>
    [DataMember(Name="payment", EmitDefaultValue=false)]
    public PaymentInfo Payment { get; set; }

    public RentalResponse(Guid rentalUid, 
        RentalStatus status,
        string dateFrom,
        string dateTo,
        Car car,
        PaymentInfo payment)
    {
        RentalUid = rentalUid;
        Status = status;
        DateFrom = dateFrom;
        DateTo = dateTo;
        Car = car;
        Payment = payment;
    }
}