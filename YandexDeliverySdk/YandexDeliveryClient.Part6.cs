using Restub.Toolbox;
using YandexDeliverySdk.DataContracts;

namespace YandexDeliverySdk;

partial class YandexDeliveryClient
{
    /// <summary>
    /// 6.01. Создание склада
    /// Создание склада.Максимум 100 на клиента
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformwarehousescreate-post 
    /// </summary>
    public string CreateWarehouse(CreateWarehouseRequest request) =>
        Post<CreateWarehouseResponse>("warehouses/create", request).StationId;

    /// <summary>
    /// 6.02. Получение списка складов клиента !!!TODO: filter!!!
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformwarehousesretrieve-post
    /// </summary>
    public GetWarehouseListResponse GetWarehouseList() =>
        Post<GetWarehouseListResponse>("warehouses/list", new
        {
            filter = new
            {
            },
        });

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
