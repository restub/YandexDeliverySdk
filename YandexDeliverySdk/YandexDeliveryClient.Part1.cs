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
    public OfferInfoResponse GetOffersInfo(OfferInfoRequest request) =>
        Get<OfferInfoResponse>("offers/info", r =>
        {
            r.AddQueryString(request);
        });
}
