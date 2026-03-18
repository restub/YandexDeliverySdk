namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class CustomLocation
{
    [DataMember(Name = "latitude")]
    public decimal Latitude { get; set; }

    [DataMember(Name = "longitude")]
    public decimal Longitude { get; set; }

    [DataMember(Name = "details")]
    public LocationDetails Details { get; set; }
}
