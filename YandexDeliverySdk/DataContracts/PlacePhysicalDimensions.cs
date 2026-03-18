namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 1.01. Предварительная оценка стоимости доставки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformpricing-calculator-post
/// </summary>
[DataContract]
public class PlacePhysicalDimensions
{
    [DataMember(Name = "weight_gross")]
    public long WeightGross { get; set; }

    [DataMember(Name = "dx")]
    public long Dx { get; set; }

    [DataMember(Name = "dy")]
    public long Dy { get; set; }

    [DataMember(Name = "dz")]
    public long Dz { get; set; }
}