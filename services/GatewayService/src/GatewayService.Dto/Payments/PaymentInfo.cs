using System.Runtime.Serialization;
using GatewayService.Dto.Payments.Enums;

namespace GatewayService.Dto.Payments;

[DataContract]
public class PaymentInfo
{
    /// <summary>
    /// UUID платежа
    /// </summary>
    /// <value>UUID платежа</value>
    [DataMember(Name="paymentUid", EmitDefaultValue=false)]
    public Guid PaymentUid { get; set; }

    /// <summary>
    /// Статус платежа
    /// </summary>
    /// <value>Статус платежа</value>
    [DataMember(Name="status", EmitDefaultValue=false)]
    public PaymentStatus Status { get; set; }

    /// <summary>
    /// Сумма платежа
    /// </summary>
    /// <value>Сумма платежа</value>
    [DataMember(Name="price", EmitDefaultValue=false)]
    public decimal Price { get; set; }

    public PaymentInfo(Guid paymentUid, 
        PaymentStatus status,
        decimal price)
    {
        PaymentUid = paymentUid;
        Status = status;
        Price = price;
    }
}