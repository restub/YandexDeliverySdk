namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 1.02. Получение интервалов доставки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformoffersinfo-get
/// </summary>
[DataContract]
public class OfferInfoResponse
{
    [DataMember(Name = "offers")]
    public OfferInfo[] Offers { get; set; }
}