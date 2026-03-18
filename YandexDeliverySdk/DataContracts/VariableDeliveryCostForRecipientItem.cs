namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class VariableDeliveryCostForRecipientItem
{
    [DataMember(Name = "min_cost_of_accepted_items")]
    public long MinCostOfAcceptedItems { get; set; }

    [DataMember(Name = "delivery_cost")]
    public long DeliveryCost { get; set; }
}