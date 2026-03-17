namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 2.02. Получение списка точек самопривоза и ПВЗ
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/2.-Tochki-samoprivoza-i-PVZ/apib2bplatformpickup-pointslist-post
/// </summary>
[DataContract]
public class PickupPointFilter
{
    [DataMember(Name = "pickup_point_ids")]
    public string[] PickupPointIds { get; set; }

    [DataMember(Name = "geo_id")]
    public long GeoId { get; set; }

    [DataMember(Name = "longitude")]
    public CoordinateInterval Longitude { get; set; }

    [DataMember(Name = "latitude")]
    public CoordinateInterval Latitude { get; set; }

    [DataMember(Name = "type")]
    public PickupStationType Type { get; set; }

    [DataMember(Name = "payment_method")]
    public PaymentMethod PaymentMethod { get; set; }

    [DataMember(Name = "available_for_dropoff")]
    public bool AvailableForDropoff { get; set; }

    [DataMember(Name = "is_yandex_branded")]
    public bool IsYandexBranded { get; set; }

    [DataMember(Name = "is_not_branded_partner_station")]
    public bool IsNotBrandedPartnerStation { get; set; }

    [DataMember(Name = "payment_methods")]
    public PaymentMethod[] PaymentMethods { get; set; }

    [DataMember(Name = "operator_ids")]
    public OperatorType[] OperatorIds { get; set; }

    [DataMember(Name = "pickup_services")]
    public PickupServices PickupServices { get; set; }
}

