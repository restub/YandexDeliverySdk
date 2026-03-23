namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 5.02. Статус регистрации мерчанта
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantregistrationstatus-get
/// </summary>
[DataContract]
public class ValidationErrorDetails
{
    [DataMember(Name = "invalid_fields")]
    public string[] InvalidFields { get; set; }
}