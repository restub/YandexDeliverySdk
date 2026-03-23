namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 5.02. Статус регистрации мерчанта
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantregistrationstatus-get
/// </summary>
[DataContract]
public class MerchantRegistrationStatus
{
    [DataMember(Name = "status")]
    public string Status { get; set; }

    [DataMember(Name = "merchant_id")]
    public string MerchantId { get; set; }

    [DataMember(Name = "error")]
    public ValidationErrorWithMessage Error { get; set; }
}
