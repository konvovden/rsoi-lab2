using System.Runtime.Serialization;

namespace GatewayService.Dto.Rental;

[DataContract]
public class CreateRentalRequest
{
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

    public CreateRentalRequest(Guid carUid,
        string dateFrom, 
        string dateTo)
    {
        CarUid = carUid;
        DateFrom = dateFrom;
        DateTo = dateTo;
    }
}