using System;
using System.Runtime.Serialization;

namespace YandexDeliverySdk.DataContracts;

/// <summary>
/// 6.05. Создать отгрузку
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformpickupscreate-post
/// Параметры отгрузки
/// </summary>
[DataContract]
public class PickupParameters
{
    [DataMember(Name = "volume_m3")]
    public string VolumeM3 { get; set; }

    [DataMember(Name = "weight_g")]
    public long WeightG { get; set; }

    [DataMember(Name = "requirements")]
    public PickupRequirements Requirements { get; set; }
}
