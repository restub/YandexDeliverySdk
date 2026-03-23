using YandexDeliverySdk.DataContracts;

namespace YandexDeliverySdk;

partial class YandexDeliveryClient
{
    /// <summary>
    /// 3.01. Создание заявки
    /// Получение вариантов доставки(офферов) для переданного заказа.
    /// При передаче нескольких идентичных товарных позиций необходимо передавать количество в параметре count.В противном случае в системе будет записано количество 1.
    /// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post
    /// </summary>
    public CreateOfferResponse CreateOffer(CreateOfferRequest request) =>
        Post<CreateOfferResponse>("offers/create", request);
}
