namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 1.01. Предварительная оценка стоимости доставки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformpricing-calculator-post
/// </summary>
[DataContract]
public class PricingSourceNode
{
    [DataMember(Name = "platform_station_id")]
    public string PlatformStationId { get; set; }
}
