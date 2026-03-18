namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class CreateOfferRequest
{
    [DataMember(Name = "info")]
    public OfferRequestInfo Info { get; set; }

    [DataMember(Name = "source")]
    public SourceRequestNode Source { get; set; }

    [DataMember(Name = "destination")]
    public DestinationRequestNode Destination { get; set; }

    [DataMember(Name = "items")]
    public RequestResourceItem[] Items { get; set; }

    [DataMember(Name = "places")]
    public ResourcePlace[] Places { get; set; }

    [DataMember(Name = "billing_info")]
    public BillingInfo BillingInfo { get; set; }

    [DataMember(Name = "recipient_info")]
    public Contact RecipientInfo { get; set; }

    [DataMember(Name = "last_mile_policy")]
    public TariffType LastMilePolicy { get; set; }

    [DataMember(Name = "particular_items_refuse")]
    public bool ParticularItemsRefuse { get; set; }

    [DataMember(Name = "forbid_unboxing")]
    public bool ForbidUnboxing { get; set; }
}
