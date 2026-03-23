namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 5.02. Статус регистрации мерчанта
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantregistrationstatus-get
/// </summary>
[DataContract]
public class ValidationErrorWithMessage
{
    [DataMember(Name = "code")]
    public string Code { get; set; }

    [DataMember(Name = "message")]
    public string Message { get; set; }

    [DataMember(Name = "details")]
    public ValidationErrorDetails Details { get; set; }
}
