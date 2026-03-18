using System;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NUnit.Framework;
using YandexDeliverySdk.DataContracts;

namespace YandexDeliverySdk.Example;

using static YandexDeliveryClient;

[TestFixture]
public class Test
{
    private YandexDeliveryClient Client { get; } = new YandexDeliveryClient
    {
        Tracer = TestContext.WriteLine,
    };

    [Test]
    public void DetectLocationReturnsLocations()
    {
        var result = Client.DetectLocation("Москва");
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Variants, Is.Not.Null);
            Assert.That(result.Variants.Length, Is.GreaterThan(0));
            Assert.That(result.Variants.First().Address, Is.EqualTo("Москва"));
            Assert.That(result.Variants.First().GeoId, Is.EqualTo(213));
        });
    }

    [Test]
    public void GetAllPickupPoints()
    {
        var result = Client.GetPickupPonts();
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Points, Is.Not.Null);
            Assert.That(result.Points.Length, Is.GreaterThan(0));
        });
    }

    [Test]
    public void GetFilteredPickupPoints()
    {
        var result = Client.GetPickupPonts(new PickupPointFilter
        { 
            GeoId = 213,
            IsYandexBranded = true,
            PaymentMethod = PaymentMethod.Postpay,
            PaymentMethods = [ PaymentMethod.BoundCard ],
        });

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Points, Is.Not.Null);
            Assert.That(result.Points.Length, Is.GreaterThan(0));
        });
    }

    [Test]
    public void CalculatePricingWorks()
    {
        var result = Client.CalculatePricing(new PricingRequest
        {
            Source = new PricingSourceNode { PlatformStationId = TestPlatform2 },
            Destination = new PricingDestinationNode { PlatformStationId = TestPlatform3 },
            TotalWeight = 5,
            Places =
            [
                new PricingResourcePlace
                {
                    PhysicalDims = new PlacePhysicalDimensions
                    {
                        Dx = 10,
                        Dy = 10,
                        Dz = 10,
                        WeightGross = 3,
                    }
                },
                new PricingResourcePlace
                {
                    PhysicalDims = new PlacePhysicalDimensions
                    {
                        Dx = 5,
                        Dy = 5,
                        Dz = 5,
                        WeightGross = 2,
                    }
                }
            ]
        });

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.DeliveryDays, Is.GreaterThanOrEqualTo(0));
            Assert.That(result.PricingAmount, Is.GreaterThanOrEqualTo(1));
            Assert.That(result.PricingTotal, Does.EndWith("RUB"));
        });
    }

    [Test]
    public void GetOffersInfoWorks()
    {
        var result = Client.GetOffersInfo(new OfferInfoRequest(TestPlatform1)
        {
            SelfPickupId = TestPlatform3,
        });

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Offers, Is.Not.Null);
            Assert.That(result.Offers.Length, Is.GreaterThanOrEqualTo(1));
            Assert.That(result.Offers[0], Is.Not.Null);
            Assert.That(result.Offers[0].From, Does.Not.EqualTo(DateTime.MinValue));
            Assert.That(result.Offers[0].From, Does.Not.EqualTo(DateTime.MaxValue));
            Assert.That(result.Offers[0].To, Does.Not.EqualTo(DateTime.MinValue));
            Assert.That(result.Offers[0].To, Does.Not.EqualTo(DateTime.MaxValue));
        });
    }

    private void Example()
    {
        // пре
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