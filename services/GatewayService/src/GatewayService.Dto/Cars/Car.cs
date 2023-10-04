using System.Runtime.Serialization;
using GatewayService.Dto.Cars.Enums;

namespace GatewayService.Dto.Cars;

[DataContract]
public class Car
{
    /// <summary>
    /// UUID автомобиля
    /// </summary>
    /// <value>UUID автомобиля</value>
    [DataMember(Name="carUid", EmitDefaultValue=false)]
    public Guid Id { get; set; }

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

    /// <summary>
    /// Мощность автомобиля в лошадиных силах
    /// </summary>
    /// <value>Мощность автомобиля в лошадиных силах</value>
    [DataMember(Name="power", EmitDefaultValue=false)]
    public decimal Power { get; set; }
    
    /// <summary>
    /// Тип автомобиля
    /// </summary>
    /// <value>Тип автомобиля</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    public CarType Type { get; set; }

    /// <summary>
    /// Цена автомобиля за сутки
    /// </summary>
    /// <value>Цена автомобиля за сутки</value>
    [DataMember(Name="price", EmitDefaultValue=false)]
    public decimal Price { get; set; }

    /// <summary>
    /// Флаг, указывающий что автомобиль доступен для бронирования
    /// </summary>
    /// <value>Флаг, указывающий что автомобиль доступен для бронирования</value>
    [DataMember(Name="available", EmitDefaultValue=false)]
    public bool Available { get; set; }

    public Car(Guid id,
        string brand,
        string model,
        string registrationNumber,
        decimal power,
        CarType type,
        decimal price,
        bool available)
    {
        Id = id;
        Brand = brand;
        Model = model;
        RegistrationNumber = registrationNumber;
        Power = power;
        Type = type;
        Price = price;
        Available = available;
    }
}