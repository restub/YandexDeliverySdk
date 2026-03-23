namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 5.01. Регистрация мерчанта
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantregistrationinit-post
/// </summary>
[DataContract]
public class CreateMerchantRequest
{
    [DataMember(Name = "site_url")]
    public string SiteUrl { get; set; }

    [DataMember(Name = "legal_info")]
    public MerchantLegalInfo LegalInfo { get; set; }

    [DataMember(Name = "contact")]
    public MerchantContactInfo Contact { get; set; }

    [DataMember(Name = "shipment_type")]
    public string ShipmentType { get; set; }
}
