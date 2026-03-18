namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 1.02. Получение интервалов доставки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformoffersinfo-get
/// </summary>
[DataContract]
public class OfferInfoRequest
{
    public OfferInfoRequest(string stationId)
    {
        StationId = stationId;
    }

    [DataMember(Name = "station_id")]
    public string StationId { get; set; }

    [DataMember(Name = "full_address")]
    public string FullAddress { get; set; }

    [DataMember(Name = "is_oversized")]
    public bool IsOversized { get; set; }

    [DataMember(Name = "last_mile_policy")]
    public TariffType LastMilePolicy { get; set; }

    [DataMember(Name = "self_pickup_id")]
    public string SelfPickupId { get; set; }

    [DataMember(Name = "send_unix")]
    public bool SendUnix { get; set; }
}