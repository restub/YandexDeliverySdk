namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 1.01. Предварительная оценка стоимости доставки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformpricing-calculator-post
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class ResourcePlace
{
    public ResourcePlace()
    {
        PhysicalDims = new PlacePhysicalDimensions();
    }

    public ResourcePlace(int dx, int dy, int dz, int weightGross)
    {
        PhysicalDims = new PlacePhysicalDimensions
        {
            Dx = dx,
            Dy = dy,
            Dz = dz,
            WeightGross = weightGross,
        };
    }

    [DataMember(Name = "physical_dims")]
    public PlacePhysicalDimensions PhysicalDims { get; set; }

    [DataMember(Name = "barcode")]
    public string Barcode { get; set; } = "unique";
}
