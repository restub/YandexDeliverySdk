using System;
using System.Runtime.Serialization;

namespace YandexDeliverySdk.DataContracts
{
    /// <summary>
    /// 5.06. Обновить информацию о мерчанте
    /// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/5.-Upravlenie-merchantami/apib2bplatformmerchantupdate-post
    /// </summary>
    [DataContract]
    public class UpdateMerchantRequest
    {
        [DataMember(Name = "legal_name")]
        public string LegalName { get; set; }

        [DataMember(Name = "site_url")]
        public string SiteUrl { get; set; }

        [DataMember(Name = "contact")]
        public MerchantContactInfo Contact { get; set; }
    }
}
