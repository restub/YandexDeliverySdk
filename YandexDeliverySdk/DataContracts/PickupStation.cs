namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 2.02. Получение списка точек самопривоза и ПВЗ
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/2.-Tochki-samoprivoza-i-PVZ/apib2bplatformpickup-pointslist-post
/// </summary>
[DataContract]
public class PickupStation
{
    [DataMember(Name = "id")]
    public string Id { get; set; }

    [DataMember(Name = "operator_station_id")]
    public string OperatorStationId { get; set; }

    [DataMember(Name = "operator_id")]
    public string OperatorId { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "type")]
    public PickupStationType Type { get; set; }

    [DataMember(Name = "position")]
    public GeoPoint Position { get; set; }

    [DataMember(Name = "address")]
    public LocationDetails Address { get; set; }

    [DataMember(Name = "instruction")]
    public string Instruction { get; set; }

    [DataMember(Name = "payment_methods")]
    public PaymentMethod[] PaymentMethods { get; set; }

    [DataMember(Name = "contact")]
    public StationContact Contact { get; set; }

    [DataMember(Name = "schedule")]
    public StationSchedule Schedule { get; set; }

    [DataMember(Name = "is_yandex_branded")]
    public bool IsYandexBranded { get; set; }

    [DataMember(Name = "is_market_partner")]
    public bool IsMarketPartner { get; set; }

    [DataMember(Name = "is_dark_store")]
    public bool IsDarkStore { get; set; }

    [DataMember(Name = "is_post_office")]
    public bool IsPostOffice { get; set; }

    [DataMember(Name = "dayoffs")]
    public DayOffs[] Dayoffs { get; set; }

    [DataMember(Name = "deactivation_date")]
    public string DeactivationDate { get; set; }

    [DataMember(Name = "deactivation_date_predicted_debt")]
    public string DeactivationDatePredictedDebt { get; set; }

    [DataMember(Name = "available_for_dropoff")]
    public bool AvailableForDropoff { get; set; }

    [DataMember(Name = "available_for_c2c_dropoff")]
    public bool AvailableForC2cDropoff { get; set; }

    [DataMember(Name = "pickup_services")]
    public PickupServices PickupServices { get; set; }
}
