namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class OfferDetails
{
    [DataMember(Name = "delivery_interval")]
    public DeliveryIntervalUTC DeliveryInterval { get; set; }

    [DataMember(Name = "pickup_interval")]
    public PickupIntervalUTC PickupInterval { get; set; }

    [DataMember(Name = "pricing")]
    public string Pricing { get; set; }

    [DataMember(Name = "pricing_commission_on_delivery_payment")]
    public string PricingCommissionOnDeliveryPayment { get; set; }

    [DataMember(Name = "pricing_commission_on_delivery_payment_amount")]
    public string PricingCommissionOnDeliveryPaymentAmount { get; set; }

    [DataMember(Name = "pricing_total")]
    public string PricingTotal { get; set; }
}
