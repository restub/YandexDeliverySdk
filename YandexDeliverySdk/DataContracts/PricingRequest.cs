namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 1.01. Предварительная оценка стоимости доставки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformpricing-calculator-post
/// </summary>
[DataContract]
public class PricingRequest
{
    [DataMember(Name = "source")]
    public SourceNode Source { get; set; }

    [DataMember(Name = "destination")]
    public DestinationNode Destination { get; set; }

    [DataMember(Name = "tariff")]
    public TariffType Tariff { get; set; }

    [DataMember(Name = "total_weight")]
    public long TotalWeight { get; set; }

    [DataMember(Name = "total_assessed_price")]
    public decimal TotalAssessedPrice { get; set; }

    [DataMember(Name = "client_price")]
    public decimal ClientPrice { get; set; }

    [DataMember(Name = "payment_method")]
    public PaymentMethod PaymentMethod { get; set; }

    [DataMember(Name = "places")]
    public ResourcePlace[] Places { get; set; }
}
