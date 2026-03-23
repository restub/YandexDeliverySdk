using System.Linq;
using NUnit.Framework;
using YandexDeliverySdk;
using YandexDeliverySdk.DataContracts;

namespace YandexDeliveryTests;
partial class Test
{
    [Test]
    public void DetectLocationReturnsLocations()
    {
        var result = TestClient.DetectLocation("Москва");
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
        var result = TestClient.GetPickupPoints();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Points, Is.Not.Null);
            Assert.That(result.Points, Has.Length.GreaterThan(0));
        }
    }

    [Test]
    public void GetFilteredPickupPointsWorksOnTestClient()
    {
        var result = TestClient.GetPickupPoints(new PickupPointFilter
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
    public void GetFilteredPickupPointsWorksOnMainClient()
    {
        var result = MainClient.GetPickupPoints(new PickupPointFilter
        {
            GeoId = 213,
            IsYandexBranded = true,
            PaymentMethod = PaymentMethod.Postpay,
            PaymentMethods = [PaymentMethod.BoundCard],
        });

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Points, Is.Not.Null);
            Assert.That(result.Points, Has.Length.GreaterThan(0));
        }
    }
}
