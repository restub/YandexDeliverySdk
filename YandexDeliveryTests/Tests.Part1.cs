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
    [Test]
    public void CalculatePricingWorks()
    {
        var result = TestClient.CalculatePricing(new PricingRequest
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
        var result = TestClient.GetOffersInfo(
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
            TestClient.GetOffersInfo(
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
        var result = TestClient.GetOffersInfo(new OfferInfoRequest
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
            TestClient.GetOffersInfo(new OfferInfoRequest
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
}
