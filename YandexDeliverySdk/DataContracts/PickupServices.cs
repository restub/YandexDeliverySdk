namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 2.02. Получение списка точек самопривоза и ПВЗ
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/2.-Tochki-samoprivoza-i-PVZ/apib2bplatformpickup-pointslist-post
/// </summary>
[DataContract]
public class PickupServices
{
    [DataMember(Name = "is_fitting_allowed")]
    public bool IsFittingAllowed { get; set; }

    [DataMember(Name = "is_partial_refuse_allowed")]
    public bool IsPartialRefuseAllowed { get; set; }

    [DataMember(Name = "is_paperless_pickup_allowed")]
    public bool IsPaperlessPickupAllowed { get; set; }

    [DataMember(Name = "is_unboxing_allowed")]
    public bool IsUnboxingAllowed { get; set; }
}
