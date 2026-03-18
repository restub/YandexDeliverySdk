namespace YandexDeliverySdk.DataContracts;

using System.Globalization;
using System.Runtime.Serialization;

/// <summary>
/// 1.01. Предварительная оценка стоимости доставки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformpricing-calculator-post
/// </summary>
[DataContract]
public class PricingResponse
{
    [DataMember(Name = "pricing_total")]
    public string PricingTotal { get; set; }

    [IgnoreDataMember]
    public decimal PricingAmount
    {
        get
        {
            var pricing = PricingTotal + " ";
            pricing = pricing.Substring(0, pricing.IndexOf(' '));
            return decimal.TryParse(pricing, NumberStyles.Currency,
                CultureInfo.InvariantCulture, out var result) ? result : 0;
        }
        set
        {
            PricingTotal = $"{value:0.00} RUB";
        }
    }

    [DataMember(Name = "delivery_days")]
    public int DeliveryDays { get; set; }
}
