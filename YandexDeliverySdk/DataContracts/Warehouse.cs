namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 6.03. Получение информации о складе
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformwarehousesretrieve-post
/// </summary>
[DataContract]
public class Warehouse
{
    [DataMember(Name = "station_id")]
    public string StationId { get; set; }

    [DataMember(Name = "client_warehouse_id")]
    public string ClientWarehouseId { get; set; }

    [DataMember(Name = "merchant_id")]
    public string MerchantId { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "coordinates")]
    public GeoPoint Coordinates { get; set; }

    [DataMember(Name = "location")]
    public WarehouseLocation Location { get; set; }

    [DataMember(Name = "contact")]
    public WarehouseContact Contact { get; set; }
}
