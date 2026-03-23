namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 5.04. Найти мерчантов
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantsfind-post
/// </summary>
[DataContract]
public class MerchantInfo
{
    [DataMember(Name = "id")]
    public string Id { get; set; }

    [DataMember(Name = "external_id")]
    public string ExternalId { get; set; }

    [DataMember(Name = "is_removed")]
    public bool IsRemoved { get; set; }

    [DataMember(Name = "legal_name")]
    public string LegalName { get; set; }

    [DataMember(Name = "inn")]
    public string Inn { get; set; }
}