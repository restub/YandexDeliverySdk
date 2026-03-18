using System;
using System.Net;
using Restub;
using YandexDeliverySdk.DataContracts;

namespace YandexDeliverySdk;

[Serializable]
public class YandexDeliveryException : RestubException
{
    public YandexDeliveryException(HttpStatusCode code, string message, Exception inner = null, ErrorInfo error = null)
        : base(code, message, inner)
    {
    }

    public ErrorInfo ErrorInfo
    {
        get => Data[nameof(ErrorInfo)] as ErrorInfo;
        set => Data[nameof(ErrorInfo)] = value;
    }
}
