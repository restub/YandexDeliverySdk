namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 5.01. Регистрация мерчанта
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantregistrationinit-post
/// </summary>
[DataContract]
public class CreateMerchantResponse
{
    [DataMember(Name = "registration_id")]
    public string RegistrationId { get; set; }
}
