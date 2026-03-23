namespace YandexDeliverySdk.DataContracts;

using System.Runtime.Serialization;

/// <summary>
/// 6.03. Получение информации о складе
/// https://yandex.ru/support/delivery-profile/ru/api/other-day/ref/6.-Upravlenie-skladami-i-otgruzkami/apib2bplatformwarehousesretrieve-post
/// </summary>
[DataContract]
public class WarehouseContact
{
    [DataMember(Name = "first_name")]
    public string FirstName { get; set; }

    [DataMember(Name = "last_name")]
    public string LastName { get; set; }

    [DataMember(Name = "patronymic")]
    public string Patronymic { get; set; }

    [DataMember(Name = "phone")]
    public string Phone { get; set; }

    [DataMember(Name = "email")]
    public string Email { get; set; }
}