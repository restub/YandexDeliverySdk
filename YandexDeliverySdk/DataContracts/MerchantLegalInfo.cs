namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 5.01. Регистрация мерчанта
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantregistrationinit-post
/// </summary>
[DataContract]
public class MerchantLegalInfo
{
    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "inn")]
    public string Inn { get; set; }

    [DataMember(Name = "ogrn")]
    public string Ogrn { get; set; }

    [DataMember(Name = "kpp")]
    public string Kpp { get; set; }

    [DataMember(Name = "type")]
    public string Type { get; set; }

    [DataMember(Name = "address")]
    public MerchantAddress Address { get; set; }
}
