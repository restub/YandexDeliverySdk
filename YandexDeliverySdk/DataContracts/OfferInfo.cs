namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 1.02. Получение интервалов доставки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformoffersinfo-get
/// </summary>
[DataContract]
public class OfferInfo
{
    [DataMember(Name = "from")]
    public DateTime From { get; set; }

    [DataMember(Name = "to")]
    public DateTime To { get; set; }
}
