namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 2.02. Получение списка точек самопривоза и ПВЗ
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/2.-Tochki-samoprivoza-i-PVZ/apib2bplatformpickup-pointslist-post
/// </summary>
[DataContract]
public class StationScheduleRestriction
{
    [DataMember(Name = "days")]
    public long[] Days { get; set; }

    [DataMember(Name = "time_from")]
    public DayTime TimeFrom { get; set; }

    [DataMember(Name = "time_to")]
    public DayTime TimeTo { get; set; }
}
