namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 2.01. Получение идентификатора населенного пункта
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/2.-Tochki-samoprivoza-i-PVZ/apib2bplatformlocationdetect-post
/// </summary>
[DataContract]
public class LocationDetectedVariant
{
    [DataMember(Name = "geo_id")]
    public long GeoId { get; set; }

    [DataMember(Name = "address")]
    public string Address { get; set; }
}