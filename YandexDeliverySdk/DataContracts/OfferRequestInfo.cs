namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class OfferRequestInfo
{
    [DataMember(Name = "operator_request_id")]
    public string OperatorRequestId { get; set; }

    [DataMember(Name = "merchant_id")]
    public string MerchantId { get; set; }

    [DataMember(Name = "comment")]
    public string Comment { get; set; }
}
