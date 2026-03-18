using Restub.Toolbox;
using YandexDeliverySdk.DataContracts;

namespace YandexDeliverySdk;

partial class YandexDeliveryClient
{
    /// <summary>
    /// 1.01. Предварительная оценка стоимости доставки
    /// Расчет стоимости доставки на основании переданных параметров заказа
    /// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformpricing-calculator-post
    /// </summary>
    public PricingResponse CalculatePricing(PricingRequest request, bool isOversized = false) =>
        Post<PricingResponse>("pricing-calculator", request, r =>
        {
            if (isOversized)
            {
                r.AddQueryParameter("is_oversized", isOversized.ToString().ToLower());
            }
        });

    /// <summary>
    /// 1.02. Получение интервалов доставки
    /// Получение расписания вывозов в регионы.В качестве конечного пункта нужно указать либо full_address(строковый конечный адрес), либо self_pickup_id(ID ПВЗ)
    /// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformoffersinfo-get
    /// </summary>
    public OfferInfoResponse GetOffersInfo(string stationId,
        string fullAddress = null, string selfPickupStationId = null,
        bool isOversized = false, TariffType lastMilePolicy = TariffType.TimeInterval) =>
        Get<OfferInfoResponse>("offers/info", r =>
        {
            // сериализатор пригодится в extension-методах
            r.JsonSerializer = Serializer;
            r.AddQueryParameter("station_id", stationId);
            r.AddQueryParameterIfNotEmpty("full_address", fullAddress);
            r.AddQueryParameterIfNotEmpty("self_pickup_id", selfPickupStationId);
            r.AddQueryParameterIfNotDefault("is_oversized", isOversized);
            r.AddQueryParameterIfNotDefault("last_mile_policy", lastMilePolicy, TariffType.TimeInterval);
            // параметр "send_unix" не нужен и не поддерживается
        });

    /// <summary>
    /// 1.03. Получение интервалов доставки #2
    /// Получение расписания вывозов в регионы. В качестве конечного пункта нужно указать либо address (строковый конечный адрес), либо platform_station_id (ID ПВЗ)
    /// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformoffersinfo-post
    /// </summary>
    public OfferInfoResponse GetOffersInfo(OfferInfoRequest request) =>
        Post<OfferInfoResponse>("offers/info", request, r =>
        {
            // сериализатор пригодится в extension-методах
            r.JsonSerializer = Serializer;
            r.AddQueryParameterIfNotDefault("is_oversized", request.IsOversized);
            r.AddQueryParameterIfNotDefault("last_mile_policy", request.LastMilePolicy, TariffType.TimeInterval);
        });
}
