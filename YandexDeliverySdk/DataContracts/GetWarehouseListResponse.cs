using System;
using System.Runtime.Serialization;

namespace YandexDeliverySdk.DataContracts
{
    /// <summary>
    /// 6.02. Получение списка складов клиента
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformwarehouseslist-post
    /// </summary>
    [DataContract]
    public class GetWarehouseListResponse
    {
        [DataMember(Name = "warehouses")]
        public Warehouse[] Warehouses { get; set; }
    }
}