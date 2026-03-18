namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;

/// <summary>
/// 3.01. Создание заявки
/// https://yandex.com/support/delivery-profile/ru/api/other-day/ref/3.-Osnovnye-zaprosy/apib2bplatformofferscreate-post#entity-ItemBillingDetails
/// </summary>
[DataContract]
public class Contact
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