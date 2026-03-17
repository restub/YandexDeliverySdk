namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// Статусная модель
/// https://yandex.com/support/delivery-profile/ru/api/other-day/status-model
/// </summary>
[DataContract]
public enum OrderStatus
{
    [EnumMember(Value = "DRAFT")]
    Draft,

    [EnumMember(Value = "VALIDATING")]
    Validating,

    [EnumMember(Value = "VALIDATING_ERROR")]
    ValidatingError,

    [EnumMember(Value = "CREATED")]
    Created,

    [EnumMember(Value = "DELIVERY_PROCESSING_STARTED")]
    DeliveryProcessingStarted,

    [EnumMember(Value = "DELIVERY_TRACK_RECIEVED")]
    DeliveryTrackReceived,

    [EnumMember(Value = "SORTING_CENTER_PROCESSING_STARTED")]
    SortingCenterProcessingStarted,

    [EnumMember(Value = "SORTING_CENTER_TRACK_RECEIVED")]
    SortingCenterTrackReceived,

    [EnumMember(Value = "SORTING_CENTER_TRACK_LOADED")]
    SortingCenterTrackLoaded,

    [EnumMember(Value = "DELIVERY_LOADED")]
    DeliveryLoaded,

    [EnumMember(Value = "SORTING_CENTER_LOADED")]
    SortingCenterLoaded,

    [EnumMember(Value = "SORTING_CENTER_AT_START")]
    SortingCenterAtStart,

    [EnumMember(Value = "SORTING_CENTER_PREPARED")]
    SortingCenterPrepared,

    [EnumMember(Value = "SORTING_CENTER_TRANSMITTED")]
    SortingCenterTransmitted,

    [EnumMember(Value = "DELIVERY_AT_START")]
    DeliveryAtStart,

    [EnumMember(Value = "DELIVERY_TRANSPORTATION")]
    DeliveryTransportation,

    [EnumMember(Value = "DELIVERY_ARRIVED_PICKUP_POINT")]
    DeliveryArrivedPickupPoint,

    [EnumMember(Value = "DELIVERY_TRANSMITTED_TO_RECIPIENT")]
    DeliveryTransmittedToRecipient,

    [EnumMember(Value = "DELIVERY_STORAGE_PERIOD_EXPIRED")]
    DeliveryStoragePeriodExpired,

    [EnumMember(Value = "DELIVERY_STORAGE_PERIOD_EXTENDED")]
    DeliveryStoragePeriodExtended,

    [EnumMember(Value = "CONFIRMATION_CODE_RECEIVED")]
    ConfirmationCodeReceived,

    [EnumMember(Value = "PARTICULARLY_DELIVERED")]
    ParticularlyDelivered,

    [EnumMember(Value = "DELIVERY_DELIVERED")]
    DeliveryDelivered,

    [EnumMember(Value = "FINISHED")]
    Finished,

    // Статусы отмены
    [EnumMember(Value = "CANCELLED")]
    Cancelled,

    [EnumMember(Value = "CANCELLED_BY_RECIPIENT")]
    CancelledByRecipient,

    [EnumMember(Value = "CANCELLED_USER")]
    CancelledUser,

    [EnumMember(Value = "CANCELLED_IN_PLATFORM")]
    CancelledInPlatform,

    [EnumMember(Value = "SORTING_CENTER_CANCELLED")]
    SortingCenterCancelled,

    // Статусы возврата
    [EnumMember(Value = "SORTING_CENTER_RETURN_PREPARING")]
    SortingCenterReturnPreparing,

    [EnumMember(Value = "SORTING_CENTER_RETURN_PREPARING_SENDER")]
    SortingCenterReturnPreparingSender,

    [EnumMember(Value = "SORTING_CENTER_RETURN_ARRIVED")]
    SortingCenterReturnArrived,

    [EnumMember(Value = "SORTING_CENTER_RETURN_RETURNED")]
    SortingCenterReturnReturned,

    [EnumMember(Value = "RETURN_TRANSPORTATION_STARTED")]
    ReturnTransportationStarted,

    [EnumMember(Value = "RETURN_ARRIVED_DELIVERY")]
    ReturnArrivedDelivery,

    [EnumMember(Value = "RETURN_READY_FOR_PICKUP")]
    ReturnReadyForPickup,

    [EnumMember(Value = "RETURN_RETURNED")]
    ReturnReturned,

    // Другие статусы
    [EnumMember(Value = "DELIVERY_UPDATED_BY_SHOP")]
    DeliveryUpdatedByShop,

    [EnumMember(Value = "DELIVERY_UPDATED_BY_DELIVERY")]
    DeliveryUpdatedByDelivery,

    [EnumMember(Value = "CANCELED_IN_PLATFORM")]
    CanceledInPlatform
}