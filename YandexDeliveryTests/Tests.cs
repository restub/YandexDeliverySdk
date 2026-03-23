using System;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NUnit.Framework;
using Restub;
using YandexDeliverySdk;
using YandexDeliverySdk.DataContracts;

namespace YandexDeliveryTests;

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
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Variants, Is.Not.Null);
            Assert.That(result.Variants, Has.Length.GreaterThan(0));
            Assert.That(result.Variants.First().Address, Is.EqualTo("Москва"));
            Assert.That(result.Variants.First().GeoId, Is.EqualTo(213));
        }
    }

    [Test]
    public void GetAllPickupPoints()
    {
        var result = Client.GetPickupPoints();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Points, Is.Not.Null);
            Assert.That(result.Points, Has.Length.GreaterThan(0));
        }
    }

    [Test]
    public void GetFilteredPickupPoints()
    {
        var result = Client.GetPickupPoints(new PickupPointFilter
        { 
            GeoId = 213,
            IsYandexBranded = true,
            PaymentMethod = PaymentMethod.Postpay,
            PaymentMethods = [ PaymentMethod.BoundCard ],
        });

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Points, Is.Not.Null);
            Assert.That(result.Points, Has.Length.GreaterThan(0));
        }
    }

    [Test]
    public void CalculatePricingWorks()
    {
        var result = Client.CalculatePricing(new PricingRequest
        {
            Source = new SourceNode { PlatformStationId = TestPlatform2 },
            Destination = new DestinationNode { PlatformStationId = TestPlatform3 },
            TotalWeight = 5,
            Places =
            [
                new ResourcePlace
                {
                    PhysicalDims = new PlacePhysicalDimensions
                    {
                        Dx = 10,
                        Dy = 10,
                        Dz = 10,
                        WeightGross = 3,
                    }
                },
                new ResourcePlace(5, 5, 5, 2),
            ]
        });

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.DeliveryDays, Is.GreaterThanOrEqualTo(0));
            Assert.That(result.PricingAmount, Is.GreaterThanOrEqualTo(1));
            Assert.That(result.PricingTotal, Does.EndWith("RUB"));
        }
    }

    [Test]
    public void GetOffersInfoGetWorks()
    {
        var result = Client.GetOffersInfo(
            stationId: TestPlatform1, selfPickupStationId: TestPlatform3,
            lastMilePolicy: TariffType.SelfPickup, isOversized: true);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Offers, Is.Not.Null);
            Assert.That(result.Offers, Has.Length.GreaterThanOrEqualTo(1));

            var firstOffer = result.Offers[0];
            Assert.That(firstOffer, Is.Not.Null);
            Assert.That(firstOffer.From, Does.Not.EqualTo(DateTime.MinValue));
            Assert.That(firstOffer.From, Does.Not.EqualTo(DateTime.MaxValue));
            Assert.That(firstOffer.To, Does.Not.EqualTo(DateTime.MinValue));
            Assert.That(firstOffer.To, Does.Not.EqualTo(DateTime.MaxValue));
        }
    }

    [Test]
    public void GetOffersInfoGetFails()
    {
        var ex = Assert.Throws<YandexDeliveryException>(() =>
            Client.GetOffersInfo(
                stationId: TestPlatform1, selfPickupStationId: "neverwhere",
                lastMilePolicy: TariffType.SelfPickup, isOversized: true));

        using (Assert.EnterMultipleScope())
        {
            var err = ex.ErrorInfo;
            Assert.That(err, Is.Not.Null);
            Assert.That(err.Code, Is.EqualTo("validation_error"));
        }
    }

    [Test]
    public void GetOffersInfoPostWorks()
    {
        var result = Client.GetOffersInfo(new OfferInfoRequest
        {
            Source = new SourceNode { PlatformStationId = TestPlatform1 },
            Destination = new DestinationNode { PlatformStationId = TestPlatform3 },
            Places =
            [
                new ResourcePlace(10, 10, 10, 3),
                new ResourcePlace
                {
                    PhysicalDims = new PlacePhysicalDimensions
                    {
                        Dx = 5,
                        Dy = 10,
                        Dz = 15,
                        WeightGross = 2,
                    }
                },
            ],
            LastMilePolicy = TariffType.SelfPickup,
            IsOversized = true,
        });

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Offers, Is.Not.Null);
            Assert.That(result.Offers, Has.Length.GreaterThanOrEqualTo(1));

            var firstOffer = result.Offers[0];
            Assert.That(firstOffer, Is.Not.Null);
            Assert.That(firstOffer.From, Does.Not.EqualTo(DateTime.MinValue));
            Assert.That(firstOffer.From, Does.Not.EqualTo(DateTime.MaxValue));
            Assert.That(firstOffer.To, Does.Not.EqualTo(DateTime.MinValue));
            Assert.That(firstOffer.To, Does.Not.EqualTo(DateTime.MaxValue));
        }
    }

    [Test]
    public void GetOffersInfoPostFails()
    {
        var ex = Assert.Throws<YandexDeliveryException>(() =>
            Client.GetOffersInfo(new OfferInfoRequest
            {
                Source = new SourceNode { PlatformStationId = TestPlatform1 },
                Destination = new DestinationNode { PlatformStationId = "nowherelse" },
            }));

        using (Assert.EnterMultipleScope())
        {
            var err = ex.ErrorInfo;
            Assert.That(err, Is.Not.Null);
            Assert.That(err.Code, Is.EqualTo("validation_error"));
        }
    }

    [Test]
    public void GetWarehouseWorks()
    {
        var result = Client.GetWarehouse(TestPlatform1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Warehouse, Is.Not.Null);
            Assert.That(result.Warehouse.Name, Is.Not.Null.And.Not.Empty);

            // у тестового склада не указан merchantId
            // Assert.That(result.Warehouse.MerchantId, Is.Not.Null.And.Not.Empty);
        }
    }

    [Test]
    public void GetWarehouseFails()
    {
        var ex = Assert.Throws<YandexDeliveryException>(() =>
            Client.GetWarehouse(TestPlatform1 + "oops"));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(ex.ErrorInfo, Is.Not.Null);
            Assert.That(ex.ErrorInfo.Code, Is.EqualTo("not_found"));
            Assert.That(ex.ErrorInfo.Message, Is.Not.Null.And.Not.Empty);
        }
    }

    [Test] [Ignore("Access denied, error 401")]
    public void CreateMerchantWorks()
    {
        var registrationId = Client.CreateMerchant("123", new CreateMerchantRequest
        {
            SiteUrl = "example.ru",
            LegalInfo = new MerchantLegalInfo
            {
                Name = "Мерч 2.0",
                Inn = "9715386101",
                Ogrn = "1215573935220",
                Kpp = "773691001",
                Type = "ООО",
                Address = new MerchantAddress
                {
                    FullAddress = "Москва, Пролетарский проспект, 19"
                }
            },
            Contact = new MerchantContactInfo
            {
                Name = "Пупкин Василий Михайлович",
                RepresentativeName = "Пупкин Василий Михайлович",
                Phone = "+79529999999",
                Email = "example@mail.ru"
            },
            ShipmentType = "import"
        });

        using (Assert.EnterMultipleScope())
        {
            Assert.That(registrationId, Is.Not.Null);
        }
    }

    [Test] [Ignore("Access denied, error 401")]
    public void GetMerchantRegistrationStatusWorks()
    {
        var result = Client.GetMerchantRegistrationStatus(
            "1929e056e1864cb38a392f013ad103bc/0d565a3a6dfd4ca491340cf33a8a3f65");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Status, Is.Not.Null);
        }
    }

    [Test] [Ignore("Access denied, error 401")]
    public void GetMerchantWorks()
    {
        var result = Client.GetMerchant("0c57602f56954dfa8eccd2dd498883e4");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
        }
    }

    [Test] [Ignore("Access denied, error 401")]
    public void FindMerchantWorks()
    {
        var result = Client.FindMerchant("9715386101");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Merchants, Is.Not.Null);
            Assert.That(result.Merchants, Has.Length.GreaterThanOrEqualTo(1));
        }
    }

    [Test] [Ignore("Access denied, error 401")]
    public void DeleteUnknownMerchantFails()
    {
        var ex = Assert.Throws<YandexDeliveryException>(() =>
            Client.DeleteMerchant("123"));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(ex.ErrorInfo, Is.Not.Null);
            Assert.That(ex.ErrorInfo.Code, Is.EqualTo("not_found"));
            Assert.That(ex.ErrorInfo.Message, Is.Not.Null.And.Not.Empty);
        }
    }

    [Test] [Ignore("Access denied, error 401")]
    public void UpdateMerchantWorks()
    {
        Client.UpdateMerchant("290587090cfc4943856851c8c3b2eebf", new UpdateMerchantRequest
        {
            LegalName = "Мерч 2.0",
            SiteUrl = "example.ru",
            Contact = new MerchantContactInfo
            {
                Name = "Пупкин Василий Михайлович",
                RepresentativeName = "Пупкин Василий Михайлович",
                Phone = "+79529999999",
                Email = "example@mail.ru",
            },
        });
    }

    [Test] [Ignore("Merchant not found, bad request, error 400")]
    public void CreateOfferWorks()
    {
        var result = Client.CreateOffer(new CreateOfferRequest
        {
            Info = new OfferRequestInfo
            {
                OperatorRequestId = "lKF4565ml",
                MerchantId = "290587090cfc4943856851c8c3b2eebf",
                Comment = "Комментарий"
            },
            Source = new SourceRequestNode
            {
                PlatformStation = new PlatformStation
                {
                    PlatformId = "e1139f6d-e34f-47a9-a55f-31f032a861a6"
                },
                IntervalUtc = new TimeIntervalUTC
                {
                    From = new DateTime(2021, 10, 25, 15, 0, 0, DateTimeKind.Utc),
                    To = new DateTime(2021, 10, 25, 15, 0, 0, DateTimeKind.Utc)
                }
            },
            Destination = new DestinationRequestNode
            {
                Type = DestinationRequestNodeType.CustomLocation,
                PlatformStation = null,
                CustomLocation = new CustomLocation
                {
                    Latitude = 0.5m,
                    Longitude = 0.5m,
                    Details = new LocationDetails
                    {
                        GeoId = 213,
                        Country = "Россия",
                        Region = "Москва",
                        SubRegion = "Московская область",
                        Locality = "Москва",
                        Street = "Пролетарский проспект",
                        House = "19",
                        Housing = "1",
                        Apartment = "2",
                        Building = "1",
                        Comment = "Станция метро Щукинская (4выход) второй дом слева. Вход со двора с дальнего края дома. Ориентир вывеска Яндекс Маркет",
                        FullAddress = "Москва, Пролетарский проспект, 19",
                        PostalCode = "123182"
                    }
                },
                IntervalUtc = null
            },
            Items =
            [
                new RequestResourceItem
                {
                    Count = 1,
                    Name = "Духи",
                    Article = "YS2-2022",
                    MarkingCode = "0104640126996984215oKHnIQ;-kMAp\u001d91EE06\u001d92EQx6mn168sYnHBVjrPg1nFbkmMGp/iVwc6FJ21kX67I=",
                    BillingDetails = new ItemBillingDetails
                    {
                        Inn = "9715386101",
                        Nds = 22,
                        UnitPrice = 100,
                        AssessedUnitPrice = 100
                    },
                    PhysicalDims = new ItemPhysicalDimensions
                    {
                        Dx = 10,
                        Dy = 15,
                        Dz = 10,
                        PredefinedVolume = 20
                    },
                    PlaceBarcode = "Kia-01",
                    CargoTypes = ["80"],
                    Fitting = false
                }
            ],
            Places =
            [
                new ResourcePlace
                {
                    PhysicalDims = new PlacePhysicalDimensions
                    {
                        WeightGross = 100,
                        Dx = 10,
                        Dy = 10,
                        Dz = 10
                    },
                    Barcode = "unique",
                },
            ],
            BillingInfo = new BillingInfo
            {
                PaymentMethod = PaymentMethod.AlreadyPaid,
                DeliveryCost = 0,
                VariableDeliveryCostForRecipient =
                [
                    new VariableDeliveryCostForRecipientItem
                    {
                        MinCostOfAcceptedItems = 1,
                        DeliveryCost = 0
                    }
                ]
            },
            RecipientInfo = new Contact
            {
                FirstName = "Василий",
                LastName = "Пупкин",
                Patronymic = "Михайлович",
                Phone = "+79529999999",
                Email = "pupkin@mail.ru"
            },
            LastMilePolicy = TariffType.TimeInterval,
            ParticularItemsRefuse = false,
            ForbidUnboxing = false
        });

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Offers, Is.Not.Null);
            Assert.That(result.Offers, Has.Length.GreaterThanOrEqualTo(1));
        }
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