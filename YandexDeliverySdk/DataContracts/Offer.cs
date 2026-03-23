namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class Offer
{
    [DataMember(Name = "offer_id")]
    public string OfferId { get; set; }

    [DataMember(Name = "expires_at")]
    public string ExpiresAt { get; set; }

    [DataMember(Name = "offer_details")]
    public OfferDetails OfferDetails { get; set; }
}
