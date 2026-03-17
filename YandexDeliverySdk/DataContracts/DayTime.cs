namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 2.02. Получение списка точек самопривоза и ПВЗ
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/2.-Tochki-samoprivoza-i-PVZ/apib2bplatformpickup-pointslist-post
/// </summary>
[DataContract]
public class DayTime
{
    [DataMember(Name = "hours")]
    public int Hours { get; set; }

    [DataMember(Name = "minutes")]
    public int Minutes { get; set; }
}
