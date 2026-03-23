namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 6.03. Получение информации о складе
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformwarehousesretrieve-post
/// </summary>
[DataContract]
public class WarehouseAddress
{
    [DataMember(Name = "city")]
    public string City { get; set; }

    [DataMember(Name = "country")]
    public string Country { get; set; }

    [DataMember(Name = "region")]
    public string Region { get; set; }

    [DataMember(Name = "street")]
    public string Street { get; set; }

    [DataMember(Name = "house")]
    public string House { get; set; }

    [DataMember(Name = "building")]
    public string Building { get; set; }

    [DataMember(Name = "apartment")]
    public string Apartment { get; set; }

    [DataMember(Name = "floor")]
    public string Floor { get; set; }

    [DataMember(Name = "entrance")]
    public string Entrance { get; set; }

    [DataMember(Name = "door_code")]
    public string DoorCode { get; set; }

    [DataMember(Name = "postal_code")]
    public string PostalCode { get; set; }

    [DataMember(Name = "geo_id")]
    public long GeoId { get; set; }
}
