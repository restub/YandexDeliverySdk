namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 6.03. Получение информации о складе
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformwarehousesretrieve-post
/// </summary>
[DataContract]
public class GetWarehouseResponse
{
    [DataMember(Name = "warehouse")]
    public Warehouse Warehouse { get; set; }
}
