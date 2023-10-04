using System.Runtime.Serialization;
using System.Text;

namespace GatewayService.Dto.Cars;

[DataContract]
public class PaginationResponse
{
    /// <summary>
    /// Номер страницы
    /// </summary>
    /// <value>Номер страницы</value>
    [DataMember(Name="page", EmitDefaultValue=false)]
    public decimal Page { get; set; }

    /// <summary>
    /// Количество элементов на странице
    /// </summary>
    /// <value>Количество элементов на странице</value>
    [DataMember(Name="pageSize", EmitDefaultValue=false)]
    public decimal PageSize { get; set; }

    /// <summary>
    /// Общее количество элементов
    /// </summary>
    /// <value>Общее количество элементов</value>
    [DataMember(Name="totalElements", EmitDefaultValue=false)]
    public decimal TotalElements { get; set; }

    /// <summary>
    /// Gets or Sets Items
    /// </summary>
    [DataMember(Name="items", EmitDefaultValue=false)]
    public List<CarResponse> Items { get; set; }

    public PaginationResponse(decimal page,
        decimal pageSize,
        decimal totalElements,
        List<CarResponse> items)
    {
        Page = page;
        PageSize = pageSize;
        TotalElements = totalElements;
        Items = items;
    }
}