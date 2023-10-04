using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GatewayService.Dto.Cars.Enums;

/// <summary>
/// Тип автомобиля
/// </summary>
/// <value>Тип автомобиля</value>
[JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public enum CarType
{
    [EnumMember(Value = "SEDAN")]
    Sedan = 1,
            
    [EnumMember(Value = "SUV")]
    Suv = 2,
            
    [EnumMember(Value = "MINIVAN")]
    Minivan = 3,
            
    [EnumMember(Value = "ROADSTER")]
    Roadster = 4
}