using System;
using NUnit.Framework;
using YandexDeliverySdk;

namespace YandexDeliveryTests;

using static YandexDeliveryClient;

[TestFixture]
public partial class Test
{
    private static YandexDeliveryClient TestClient { get; } = new YandexDeliveryClient
    {
        Tracer = TestContext.WriteLine,
    };

    private string ApiToken { get; set; } = string.Empty;

    private string ApiBaseUrl { get; set; } = TestUrl;

    private string MerchantId { get; set; } = string.Empty;

    private YandexDeliveryClient MainClient { get; set; } = TestClient;

    [SetUp]
    public void SetUp()
    {
        // Получаем переменные, загруженные из .env или заданные в секретах CI
        ApiToken = Environment.GetEnvironmentVariable("YANDEX_DELIVERY_API_TOKEN");
        ApiBaseUrl = Environment.GetEnvironmentVariable("YANDEX_DELIVERY_API_URL");
        MerchantId = Environment.GetEnvironmentVariable("YANDEX_DELIVERY_MERCHANT_ID");

        // Если получилось, создаем дополнительного клиента
        if (!string.IsNullOrEmpty(ApiToken) && !string.IsNullOrEmpty(ApiBaseUrl))
        {
            MainClient = new YandexDeliveryClient(ApiBaseUrl, ApiToken)
            {
                Tracer = TestContext.WriteLine,
            };
        }
    }

    private void Example()
    {
        /* Создание тестовой заявки
        var claim = new Claim
        {
            RoutePoints = new List<RoutePoint>
            {
                new RoutePoint
                {
                    PointId = 1,
                    VisitOrder = 1,
                    Type = "source",
                    Address = new Address
                    {
                        Fullname = "Москва, ул. Тверская, 1",
                        Coordinates = new double[] { 37.6173, 55.7558 }
                    },
                    Contact = new Contact
                    {
                        Name = "Отправитель",
                        Phone = "+79001234567"
                    }
                },
                new RoutePoint
                {
                    PointId = 2,
                    VisitOrder = 2,
                    Type = "destination",
                    Address = new Address
                    {
                        Fullname = "Москва, ул. Арбат, 10",
                        Coordinates = new double[] { 37.589, 55.75 }
                    },
                    Contact = new Contact
                    {
                        Name = "Получатель",
                        Phone = "+79007654321"
                    }
                }
            },
            Items = new List<Item>
            {
                new Item
                {
                    Title = "Документы",
                    Quantity = 1,
                    CostValue = "100",
                    Size = new Size { Length = 0.1m, Width = 0.1m, Height = 0.1m },
                    PickupPoint = 1,
                    DropoffPoint = 2,
                    Weight = 0.5m
                }
            }
        };

        try
        {
            Console.WriteLine("Создание заявки...");
            var createResult = client.CreateClaim(claim);
            Console.WriteLine($"Заявка создана. Результат: {createResult}");

            // Получение информации о заявке (нужен claim_id из createResult)
            // var claimId = "abc123";
            // var info = client.GetClaimInfo(claimId);
            // Console.WriteLine($"Статус заявки: {info.Status}");

            // Расчёт стоимости
            Console.WriteLine("Расчёт стоимости...");
            var priceResult = client.CheckPrice(claim);
            Console.WriteLine($"Стоимость: {priceResult}");

            // Пример расчёта вариантов доставки (v2)
            var routePoints = new List<RoutePointWithAddress>
            {
                new RoutePointWithAddress
                {
                    Id = 1,
                    Fullname = "Москва, ул. Тверская, 1",
                    Coordinates = new double[] { 37.6173, 55.7558 }
                },
                new RoutePointWithAddress
                {
                    Id = 2,
                    Fullname = "Москва, ул. Арбат, 10",
                    Coordinates = new double[] { 37.589, 55.75 }
                }
            };
            var offerResult = client.CalculateOffers(routePoints);
            Console.WriteLine($"Варианты доставки: {offerResult}");
        }
        catch (YandexDeliveryApiException ex)
        {
            Console.WriteLine($"Ошибка API: {ex.ErrorCode} - {ex.Message} (HTTP {ex.HttpStatusCode})");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Общая ошибка: {ex.Message}");
        }*/
    }
}