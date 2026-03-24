using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using static YandexDeliverySdk.Serialization.FlexibleDateTimeConverter;

namespace YandexDeliverySdk.DataContracts;

/// <summary>
/// 6.05. Создать отгрузку
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformpickupscreate-post
/// </summary>
[DataContract]
public class CreatePickupRequest
{
    [DataMember(Name = "station_id")]
    public string StationId { get; set; }

    [DataMember(Name = "pickup_local_date")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string PickupLocalDateString
    {
        get => FormatShortDate(PickupLocalDate);
        set => PickupLocalDate = ParseShortDate(value);
    }

    [IgnoreDataMember]
    public DateTime PickupLocalDate { get; set; }

    [DataMember(Name = "pickup_local_time_interval")]
    public LocalTimeInterval PickupLocalTimeInterval { get; set; }

    [DataMember(Name = "parameters")]
    public PickupParameters Parameters { get; set; }
}
