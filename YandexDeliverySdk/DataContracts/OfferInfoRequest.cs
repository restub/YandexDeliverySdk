namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 1.03. Получение интервалов доставки #2
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformoffersinfo-post
/// </summary>
[DataContract]
public class OfferInfoRequest
{
    [DataMember(Name = "source")]
    public SourceNode Source { get; set; }

    [DataMember(Name = "destination")]
    public DestinationNode Destination { get; set; }

    [DataMember(Name = "places")]
    public ResourcePlace[] Places { get; set; }

    [IgnoreDataMember] // query parameter
    public bool IsOversized { get; set; }

    [IgnoreDataMember] // query parameter
    public TariffType LastMilePolicy { get; set; }

}
