namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class ItemPhysicalDimensions
{
    [DataMember(Name = "dx")]
    public long Dx { get; set; }

    [DataMember(Name = "dy")]
    public long Dy { get; set; }

    [DataMember(Name = "dz")]
    public long Dz { get; set; }

    [DataMember(Name = "predefined_volume")]
    public long PredefinedVolume { get; set; }
}
