namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class DestinationRequestNode
{
    [DataMember(Name = "type")]
    public DestinationRequestNodeType Type { get; set; }

    [DataMember(Name = "platform_station")]
    public PlatformStation PlatformStation { get; set; }

    [DataMember(Name = "custom_location")]
    public CustomLocation CustomLocation { get; set; }

    [DataMember(Name = "interval_utc")]
    public TimeIntervalUTC IntervalUtc { get; set; }
}
