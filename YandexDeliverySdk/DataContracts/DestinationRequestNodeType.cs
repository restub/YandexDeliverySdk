namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public enum DestinationRequestNodeType
{
    [EnumMember(Value = "platform_station")]
    PlatformStation,

    [EnumMember(Value = "custom_location")]
    CustomLocation,
}