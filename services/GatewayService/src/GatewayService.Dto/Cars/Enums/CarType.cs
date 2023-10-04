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
    /// <summary>
    /// Enum SEDANEnum for SEDAN
    /// </summary>
    [EnumMember(Value = "SEDAN")]
    Sedan = 1,
            
    /// <summary>
    /// Enum SUVEnum for SUV
    /// </summary>
    [EnumMember(Value = "SUV")]
    Suv = 2,
            
    /// <summary>
    /// Enum MINIVANEnum for MINIVAN
    /// </summary>
    [EnumMember(Value = "MINIVAN")]
    Minivan = 3,
            
    /// <summary>
    /// Enum ROADSTEREnum for ROADSTER
    /// </summary>
    [EnumMember(Value = "ROADSTER")]
    Roadster = 4
}