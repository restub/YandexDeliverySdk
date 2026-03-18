namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class RequestResourceItem
{
    [DataMember(Name = "count")]
    public long Count { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "article")]
    public string Article { get; set; }

    [DataMember(Name = "marking_code")]
    public string MarkingCode { get; set; }

    [DataMember(Name = "billing_details")]
    public ItemBillingDetails BillingDetails { get; set; }

    [DataMember(Name = "physical_dims")]
    public ItemPhysicalDimensions PhysicalDims { get; set; }

    [DataMember(Name = "place_barcode")]
    public string PlaceBarcode { get; set; }

    [DataMember(Name = "cargo_types")]
    public string[] CargoTypes { get; set; }

    [DataMember(Name = "fitting")]
    public bool Fitting { get; set; }
}
