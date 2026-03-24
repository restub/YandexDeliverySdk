using System;
using System.Runtime.Serialization;

namespace YandexDeliverySdk.DataContracts;

/// <summary>
/// 6.04. Получить опции отгрузки для склада
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformpickupspickup-options-post
/// </summary>
[DataContract]
public class GetPickupOptionsResponse
{
    [DataMember(Name = "pickup_options")]
    public PickupOption[] PickupOptions { get; set; }
}
