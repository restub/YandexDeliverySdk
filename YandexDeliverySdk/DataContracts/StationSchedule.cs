namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 2.02. Получение списка точек самопривоза и ПВЗ
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/2.-Tochki-samoprivoza-i-PVZ/apib2bplatformpickup-pointslist-post
/// </summary>
[DataContract]
public class StationSchedule
{
    [DataMember(Name = "time_zone")]
    public long TimeZone { get; set; }

    [DataMember(Name = "restrictions")]
    public StationScheduleRestriction[] Restrictions { get; set; }
}
