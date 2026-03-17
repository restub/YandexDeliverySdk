namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 2.02. Получение списка точек самопривоза и ПВЗ
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/2.-Tochki-samoprivoza-i-PVZ/apib2bplatformpickup-pointslist-post
/// </summary>
[DataContract]
public class LocationDetails
{
    [DataMember(Name = "geoId")]
    public long GeoId { get; set; }

    [DataMember(Name = "country")]
    public string Country { get; set; }

    [DataMember(Name = "region")]
    public string Region { get; set; }

    [DataMember(Name = "subRegion")]
    public string SubRegion { get; set; }

    [DataMember(Name = "locality")]
    public string Locality { get; set; }

    [DataMember(Name = "street")]
    public string Street { get; set; }

    [DataMember(Name = "house")]
    public string House { get; set; }

    [DataMember(Name = "housing")]
    public string Housing { get; set; }

    [DataMember(Name = "apartment")]
    public string Apartment { get; set; }

    [DataMember(Name = "building")]
    public string Building { get; set; }

    [DataMember(Name = "comment")]
    public string Comment { get; set; }

    [DataMember(Name = "full_address")]
    public string FullAddress { get; set; }

    [DataMember(Name = "postal_code")]
    public string PostalCode { get; set; }
}
