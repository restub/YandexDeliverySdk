using System;
using System.Runtime.Serialization;

namespace YandexDeliverySdk.DataContracts;

/// <summary>
/// 6.04. Получить опции отгрузки для склада
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformpickupspickup-options-post
/// Локальный временной интервал
/// </summary>
[DataContract]
public class LocalTimeInterval
{
    [DataMember(Name = "from")]
    public string From { get; set; } // 10:00

    [DataMember(Name = "to")]
    public string To { get; set; }   // 15:00

    public override string ToString() => $"{From} — {To}";
}