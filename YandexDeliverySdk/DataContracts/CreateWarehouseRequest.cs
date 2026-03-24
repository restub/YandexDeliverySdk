using System;
using System.Runtime.Serialization;

namespace YandexDeliverySdk.DataContracts;

/// <summary>
/// 6.01. Создание склада
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformwarehousescreate-post
/// </summary>
[DataContract]
public class CreateWarehouseRequest
{
	[DataMember(Name = "client_warehouse_id")]
	public string ClientWarehouseId { get; set; }

	[DataMember(Name = "merchant_id")]
	public string MerchantId { get; set; }

	[DataMember(Name = "name")]
	public string Name { get; set; }

	[DataMember(Name = "location")]
	public WarehouseLocation Location { get; set; }

	[DataMember(Name = "contact")]
	public WarehouseContact Contact { get; set; }
}
