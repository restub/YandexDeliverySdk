using System;
using System.Runtime.Serialization;

namespace YandexDeliverySdk.DataContracts;

/// <summary>
/// 6.05. Создать отгрузку
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformpickupscreate-post
/// Опции отгрузки
/// </summary>
[DataContract]
public class PickupRequirements
{
    [DataMember(Name = "loaders_required")]
    public bool LoadersRequired { get; set; }
}