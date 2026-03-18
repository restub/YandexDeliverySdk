namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 1.01. Предварительная оценка стоимости доставки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformpricing-calculator-post
/// 1.03. Получение интервалов доставки #2
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformoffersinfo-post
/// </summary>
[DataContract]
public class PlacePhysicalDimensions
{
    /// <summary>
    /// Вес брутто, граммы
    /// </summary>
    [DataMember(Name = "weight_gross")]
    public long WeightGross { get; set; }

    /// <summary>
    /// Длина, сантиметры
    /// </summary>
    [DataMember(Name = "dx")]
    public long Dx { get; set; }

    /// <summary>
    /// Высота, сантиметры
    /// </summary>
    [DataMember(Name = "dy")]
    public long Dy { get; set; }

    /// <summary>
    /// Ширина, сантиметры
    /// </summary>
    [DataMember(Name = "dz")]
    public long Dz { get; set; }
}