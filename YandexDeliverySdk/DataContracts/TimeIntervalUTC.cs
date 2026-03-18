namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class TimeIntervalUTC
{
    [DataMember(Name = "from")]
    public DateTime From { get; set; }

    [DataMember(Name = "to")]
    public DateTime To { get; set; }
}
