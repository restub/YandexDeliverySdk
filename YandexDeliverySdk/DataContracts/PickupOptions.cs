using System;
using System.Runtime.Serialization;

namespace YandexDeliverySdk.DataContracts;

/// <summary>
/// 6.04. Получить опции отгрузки для склада
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformpickupspickup-options-post
/// Интервал отгрузки (локальное время склада)
/// </summary>
[DataContract]
public class PickupOption
{
    [DataMember(Name = "pickup_local_date")]
    public DateTime PickupLocalDate { get; set; }

    [DataMember(Name = "pickup_local_time_intervals")]
    public LocalTimeInterval[] PickupLocalTimeIntervals { get; set; }
}
