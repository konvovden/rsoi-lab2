using System.Runtime.Serialization;

namespace GatewayService.Dto.Cars;

[DataContract]
public class CarInfo
{
    /// <summary>
    /// UUID автомобиля
    /// </summary>
    /// <value>UUID автомобиля</value>
    [DataMember(Name="carUid", EmitDefaultValue=false)]
    public Guid CarUid { get; set; }

    /// <summary>
    /// Марка автомобиля
    /// </summary>
    /// <value>Марка автомобиля</value>
    [DataMember(Name="brand", EmitDefaultValue=false)]
    public string Brand { get; set; }

    /// <summary>
    /// Модель автомобиля
    /// </summary>
    /// <value>Модель автомобиля</value>
    [DataMember(Name="model", EmitDefaultValue=false)]
    public string Model { get; set; }

    /// <summary>
    /// Регистрационный номер автомобиля
    /// </summary>
    /// <value>Регистрационный номер автомобиля</value>
    [DataMember(Name="registrationNumber", EmitDefaultValue=false)]
    public string RegistrationNumber { get; set; }

    public CarInfo(Guid carUid, 
        string brand,
        string model,
        string registrationNumber)
    {
        CarUid = carUid;
        Brand = brand;
        Model = model;
        RegistrationNumber = registrationNumber;
    }
}