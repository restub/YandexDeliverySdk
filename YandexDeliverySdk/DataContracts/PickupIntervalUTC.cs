namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class PickupIntervalUTC
{
    [DataMember(Name = "min")]
    public string Min { get; set; }

    [DataMember(Name = "max")]
    public string Max { get; set; }
}