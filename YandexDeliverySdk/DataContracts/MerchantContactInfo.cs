namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 5.01. Регистрация мерчанта
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantregistrationinit-post
/// </summary>
[DataContract]
public class MerchantContactInfo
{
    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "representative_name")]
    public string RepresentativeName { get; set; }

    [DataMember(Name = "phone")]
    public string Phone { get; set; }

    [DataMember(Name = "email")]
    public string Email { get; set; }
}