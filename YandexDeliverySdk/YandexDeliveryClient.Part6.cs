using Restub.Toolbox;
using YandexDeliverySdk.DataContracts;

namespace YandexDeliverySdk;

partial class YandexDeliveryClient
{
    /// <summary>
    /// 6.03. Получение информации о складе
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformwarehousesretrieve-post
    /// </summary>
    public GetWarehouseResponse GetWarehouse(string stationId) =>
        Post<GetWarehouseResponse>("warehouses/retrieve", new
        {
            station_id = stationId
        });
}
