namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class ItemBillingDetails
{
    [DataMember(Name = "inn")]
    public string Inn { get; set; }

    [DataMember(Name = "nds")] // НДС: 0, 5, 7, 10, 22 или -1, если без НДС
    public int Nds { get; set; }

    [DataMember(Name = "unit_price")] // цена за единицу товара, коп
    public long UnitPrice { get; set; }

    [DataMember(Name = "assessed_unit_price")] // оценочная цена, коп
    public long AssessedUnitPrice { get; set; }
}
