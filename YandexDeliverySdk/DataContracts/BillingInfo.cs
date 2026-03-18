namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class BillingInfo
{
    [DataMember(Name = "payment_method")]
    public PaymentMethod PaymentMethod { get; set; }

    [DataMember(Name = "delivery_cost")]
    public long DeliveryCost { get; set; }

    [DataMember(Name = "variable_delivery_cost_for_recipient")]
    public VariableDeliveryCostForRecipientItem[] VariableDeliveryCostForRecipient { get; set; }
}
