using System;
using System.Runtime.Serialization;

namespace YandexDeliverySdk.DataContracts;

/// <summary>
/// 6.01. Создание склада (ответ)
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformwarehousescreate-post
/// </summary>
[DataContract]
public class CreateWarehouseResponse
{
    [DataMember(Name = "station_id")]
    public string StationId { get; set; }
}