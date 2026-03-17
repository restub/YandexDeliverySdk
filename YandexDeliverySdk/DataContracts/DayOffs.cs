namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 2.02. Получение списка точек самопривоза и ПВЗ
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/2.-Tochki-samoprivoza-i-PVZ/apib2bplatformpickup-pointslist-post
/// </summary>
[DataContract]
public class DayOffs
{
    [DataMember(Name = "date")]
    public long Date { get; set; }

    [DataMember(Name = "date_utc")]
    public DateTime DateUtc { get; set; }
}
