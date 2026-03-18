namespace YandexDeliverySdk.DataContracts;

using System;
using System.Runtime.Serialization;
using Restub.DataContracts;

/// <summary>
/// Информация об ошибке
/// </summary>
[DataContract]
[Serializable]
public class ErrorInfo : IHasErrors
{
    [DataMember(Name = "code")]
    public string Code { get; set; }

    [DataMember(Name = "message")]
    public string Message { get; set; }

    public bool HasErrors() => true;

    public string GetErrorMessage() => Message;
}