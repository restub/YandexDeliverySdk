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
    public GetWarehouseListResponse GetWarehouseList(string merchantId = null) =>
        Post<GetWarehouseListResponse>("warehouses/list", new
        {
            filter = new
            {
                merchant_id = merchantId,
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

    /// <summary>
    /// 6.04. Получить опции отгрузки для склада
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformpickupspickup-options-post
    /// </summary>
    public GetPickupOptionsResponse GetPickupOptions(string stationId) =>
        Post<GetPickupOptionsResponse>("pickups/pickup-options", new
        {
            station_id = stationId,
        });

    /// <summary>
    /// 6.05. Создать отгрузку
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformpickupscreate-post
    /// </summary>
    public string CreatePickup(CreatePickupRequest request) =>
        Post<CreatePickupResponse>("pickups/create", request).PickupId;

    /// <summary>
    /// 6.06. Отмена отгрузки
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformpickupscancel-post
    /// </summary>
    public void CancelPickup(string pickupId) =>
        Post<string>("pickups/cancel", new
        {
            pickup_id = pickupId,
        });
}
