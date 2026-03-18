namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 1.01. Предварительная оценка стоимости доставки
/// Информация о точке получения заказа
/// В объекте два параметра. Заполните один из них
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformpricing-calculator-post
/// 1.03. Получение интервалов доставки #2
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformoffersinfo-post
/// </summary>
[DataContract]
public class DestinationNode
{
    [DataMember(Name = "platform_station_id")]
    public string PlatformStationId { get; set; }

    [DataMember(Name = "address")]
    public string Address { get; set; }
}
