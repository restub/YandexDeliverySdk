using System.Reflection;
using YandexDeliverySdk.DataContracts;

namespace YandexDeliverySdk;

partial class YandexDeliveryClient
{
    /// <summary>
    /// 2.01. Получение идентификатора населенного пункта
    /// Получение идентификатора населенного пункта(geo_id) по адресу или его фрагменту.
    /// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/2.-Tochki-samoprivoza-i-PVZ/apib2bplatformlocationdetect-post
    /// </summary>
    public LocationDetectedResponse DetectLocation(string location) =>
        Post<LocationDetectedResponse>("api/b2b/platform/location/detect", new
        {
            location,
        });

    /// <summary>
    /// 2.02. Получение списка точек самопривоза и ПВЗ
    /// Получение списка точек самопривоза и самостоятельного получения заказа.
    /// Метод принимает пустое тело запроса, в этом случае вернутся все доступные точки самопривоза, ПВЗ и Постаматы.
    /// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/2.-Tochki-samoprivoza-i-PVZ/apib2bplatformpickup-pointslist-post
    /// </summary>
    public PickupPointsResponse GetPickupPonts(PickupPointFilter filter = null) =>
        Post<PickupPointsResponse>("api/b2b/platform/pickup-points/list", filter as object ?? new { });
}
