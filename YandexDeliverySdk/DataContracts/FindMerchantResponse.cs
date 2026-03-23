namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 5.04. Найти мерчантов
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantsfind-post
/// </summary>
[DataContract]
public class FindMerchantResponse
{
    [DataMember(Name = "merchants")]
    public MerchantInfo[] Merchants { get; set; }
}
