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
    public void GetWarehouseWorks()
    {
        var result = TestClient.GetWarehouse(TestPlatform1);

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
            TestClient.GetWarehouse(TestPlatform1 + "oops"));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(ex.ErrorInfo, Is.Not.Null);
            Assert.That(ex.ErrorInfo.Code, Is.EqualTo("not_found"));
            Assert.That(ex.ErrorInfo.Message, Is.Not.Null.And.Not.Empty);
        }
    }
}