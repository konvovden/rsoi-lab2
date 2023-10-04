using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using GatewayService.Dto.Payments;
using GatewayService.Dto.Rental.Enums;
using Newtonsoft.Json;

namespace GatewayService.Dto.Rental;

[DataContract]
public class CreateRentalResponse
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
    /// UUID автомобиля
    /// </summary>
    /// <value>UUID автомобиля</value>
    [DataMember(Name="carUid", EmitDefaultValue=false)]
    public Guid CarUid { get; set; }

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
    /// Gets or Sets Payment
    /// </summary>
    [DataMember(Name="payment", EmitDefaultValue=false)]
    public PaymentInfo Payment { get; set; }

    public CreateRentalResponse(Guid rentalUid, 
        RentalStatus status,
        Guid carUid,
        string dateFrom,
        string dateTo,
        PaymentInfo payment)
    {
        RentalUid = rentalUid;
        Status = status;
        CarUid = carUid;
        DateFrom = dateFrom;
        DateTo = dateTo;
        Payment = payment;
    }
}