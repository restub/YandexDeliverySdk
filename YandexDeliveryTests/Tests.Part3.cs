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

partial class Test
{
    [Test] [Ignore("Merchant not found, bad request, error 400")]
    public void CreateOfferWorks()
    {
        var result = TestClient.CreateOffer(new CreateOfferRequest
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
}