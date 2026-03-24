using System;
using System.Runtime.Serialization;

namespace YandexDeliverySdk.DataContracts;

/// <summary>
/// 6.05. Создать отгрузку
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformpickupscreate-post
/// </summary>
[DataContract]
public class CreatePickupResponse
{
    [DataMember(Name = "pickup_id")]
    public string PickupId { get; set; }
}