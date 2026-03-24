using System.Net;
using NUnit.Framework;
using YandexDeliverySdk;
using YandexDeliverySdk.DataContracts;

namespace YandexDeliveryTests;
partial class Test
{
    [Test] [Ignore("Access denied, error 401")]
    public void CreateMerchantWorks()
    {
        var registrationId = TestClient.CreateMerchant("123", new CreateMerchantRequest
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
        var result = TestClient.GetMerchantRegistrationStatus(
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
        var result = TestClient.GetMerchant("0c57602f56954dfa8eccd2dd498883e4");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
        }
    }

    [Test] [Ignore("Access denied, error 401")]
    public void FindMerchantWorks()
    {
        var result = MainClient.FindMerchant("9715386101");

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
            TestClient.DeleteMerchant("123"));

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
        TestClient.UpdateMerchant("290587090cfc4943856851c8c3b2eebf", new UpdateMerchantRequest
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
}