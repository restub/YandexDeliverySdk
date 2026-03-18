namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 1.01. Предварительная оценка стоимости доставки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/1.-Podgotovka-zayavki/apib2bplatformpricing-calculator-post
/// 2.02. Получение списка точек самопривоза и ПВЗ
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/2.-Tochki-samoprivoza-i-PVZ/apib2bplatformpickup-pointslist-post
/// </summary>
[DataContract]
public enum PaymentMethod
{
    [EnumMember(Value = "already_paid")]
    AlreadyPaid,

    [EnumMember(Value = "bound_card")]
    BoundCard,

    [EnumMember(Value = "card_on_receipt")]
    CardOnReceipt,

    [EnumMember(Value = "postpay")]
    Postpay,
}

