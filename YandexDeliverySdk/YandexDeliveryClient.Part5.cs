using Restub.Toolbox;
using YandexDeliverySdk.DataContracts;

namespace YandexDeliverySdk;

partial class YandexDeliveryClient
{
    /// <summary>
    /// 5.01. Регистрация мерчанта
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantregistrationinit-post
    /// </summary>
    public string CreateMerchant(string externalId, CreateMerchantRequest request) =>
        Post<CreateMerchantResponse>("merchant/registration/init", request, r =>
        {
            r.AddQueryParameter("external_merchant_id", externalId);
        })
        .RegistrationId;

    /// <summary>
    /// 5.02. Статус регистрации мерчанта
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantregistrationstatus-get
    /// </summary>
    public MerchantRegistrationStatus GetMerchantRegistrationStatus(string registrationId) =>
        Get<MerchantRegistrationStatus>("merchant/registration/status", r =>
        {
            r.AddQueryParameter("registration_id", registrationId);
        });


    /// <summary>
    /// 5.03. Информация о мерчанте
    /// Получить информацию о мерчанте
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantinfo-get
    /// </summary>
    public MerchantInfo GetMerchant(string merchantId) =>
        Get<MerchantInfo>("merchant/info", r =>
            r.AddQueryParameter("merchant_id", merchantId));
    

    /// <summary>
    /// 5.04. Найти мерчантов
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantsfind-post
    /// </summary>
    public FindMerchantResponse FindMerchant(string inn, bool isOnlyActive = false) =>
        Post<FindMerchantResponse>("merchants/find", new
        {
            inn, is_only_active = isOnlyActive
        });

    /// <summary>
    /// 5.05. Удалить мерчанта
    /// Позволяет удалить мерчанта.После этого он не сможет создавать заказы.
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantremove-post
    /// </summary>
    public void DeleteMerchant(string merchantId)
    {
        Post<string>("merchant/remove", new
        {
            merchant_id = merchantId,
        });
    }

    /// <summary>
    /// 5.06. Обновить информацию о мерчанте
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantupdate-post
    /// </summary>
    public void UpdateMerchant(string merchantId, UpdateMerchantRequest request)
    {
        Post<string>("merchant/update", request, r =>
        {
            r.AddQueryParameter("merchant_id", merchantId);
        });
    }
}
