using System;
using System.Linq;
using System.Net;
using NUnit.Framework;
using Sprache;
using YandexDeliverySdk;
using YandexDeliverySdk.DataContracts;

namespace YandexDeliveryTests;

using static YandexDeliveryClient;

partial class Test
{
    [Test] [Ignore("Station creation validation error, BadRequest, 400")]
    public void CreateWarehouseWorks()
    {
        var result = TestClient.CreateWarehouse(new CreateWarehouseRequest
        {
            ClientWarehouseId = "123",
            // MerchantId = "290587090cfc4943856851c8c3b2eebf", // merchant not found
            Name = "Main Store",
            Location = new WarehouseLocation
            {
                Address = new WarehouseAddress
                {
                    City = "Москва",
                    Country = "Россия",
                    Region = "Москва",
                    Street = "Долгоруковская улица",
                    House = " 25к2",
                    Apartment = "",
                    Floor = "",
                    Entrance = "",
                    GeoId = 120540
                },
                Coordinates = new GeoPoint
                {
                    Latitude = 55.776398m,
                    Longitude = 37.60198m
                }
            },
            Contact = new WarehouseContact
            {
                FirstName = "Василий",
                LastName = "Пупкин",
                Patronymic = "Михайлович",
                Phone = "+74959999999",
                Email = "pupkin@mail.ru"
            }
        });

        Assert.That(result, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void CreateWarehouseFailsIfMerchantNotFound()
    {
        var ex = Assert.Throws<YandexDeliveryException>(() =>
            TestClient.CreateWarehouse(new CreateWarehouseRequest
            {
                ClientWarehouseId = "123",
                MerchantId = "not-a-merchant",
                Name = "Main Store",
                Location = new WarehouseLocation
                {
                    Address = new WarehouseAddress
                    {
                        City = "Москва",
                        Country = "Россия",
                        Region = "Москва",
                        Street = "Долгоруковская улица",
                        House = " 25к2",
                        Apartment = "",
                        Floor = "",
                        Entrance = "",
                        GeoId = 120540
                    },
                    Coordinates = new GeoPoint
                    {
                        Latitude = 55.776398m,
                        Longitude = 37.60198m
                    }
                },
                Contact = new WarehouseContact
                {
                    FirstName = "Василий",
                    LastName = "Пупкин",
                    Patronymic = "Михайлович",
                    Phone = "+74959999999",
                    Email = "pupkin@mail.ru"
                }
            }));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
            Assert.That(ex.ErrorInfo, Is.Not.Null);
            Assert.That(ex.ErrorInfo.Code, Is.EqualTo("not_found"));
            Assert.That(ex.ErrorInfo.Message, Is.Not.Null.And.Not.Empty);
            Assert.That(ex.ErrorInfo.Message.ToLower(), Does.Contain("merchant").And.Contain("found"));
        }
    }

    [Test]
    public void GetWarehouseListWorksWithNoFilter()
    {
        var result = TestClient.GetWarehouseList();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Warehouses, Is.Not.Null);
            Assert.That(result.Warehouses, Has.Length.GreaterThan(0));

            var wh = result.Warehouses.First();
            Assert.That(wh, Is.Not.Null);
            Assert.That(wh.StationId, Is.Not.Null.And.Not.Empty);
            Assert.That(wh.ClientWarehouseId, Is.Not.Null.And.Not.Empty);
            Assert.That(wh.Location, Is.Not.Null);
            Assert.That(wh.Location.Address, Is.Not.Null);
            Assert.That(wh.Location.Address.City, Is.Not.Null.And.Not.Empty);
            Assert.That(wh.Location.Coordinates, Is.Not.Null);
            Assert.That(wh.Contact, Is.Not.Null);
        }
    }

    [Test]
    public void GetWarehouseListFailsWithMerchantFilterOnUnknownMerchant()
    {
        // "290587090cfc4943856851c8c3b2eebf" from the documentation also fails
        var ex = Assert.Throws<YandexDeliveryException>(() =>
            TestClient.GetWarehouseList("not-a-merchant"));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
            Assert.That(ex.ErrorInfo, Is.Not.Null);
            Assert.That(ex.ErrorInfo.Code, Is.EqualTo("not_found"));
            Assert.That(ex.ErrorInfo.Message, Is.Not.Null.And.Not.Empty);
            Assert.That(ex.ErrorInfo.Message.ToLower(), Does.Contain("merchant").And.Contain("found"));
        }
    }

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
            TestClient.GetWarehouse("not-a-warehouse"));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(ex.ErrorInfo, Is.Not.Null);
            Assert.That(ex.ErrorInfo.Code, Is.EqualTo("not_found"));
            Assert.That(ex.ErrorInfo.Message, Is.Not.Null.And.Not.Empty);
        }
    }

    [Test]
    public void GetPickupOptionsWorks()
    {
        var result = TestClient.GetPickupOptions(TestPlatform1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.PickupOptions, Is.Not.Null.And.Not.Empty);
            Assert.That(result.PickupOptions, Has.Length.GreaterThan(0));

            var option = result.PickupOptions.First();
            Assert.That(option, Is.Not.Null);
            Assert.That(option.PickupLocalDate, Does.Not.EqualTo(DateTime.MinValue));
            Assert.That(option.PickupLocalTimeIntervals, Is.Not.Null);
        }
    }

    [Test] [Ignore("A different pickup... already exists for the same date and station, Conflict, 409")] 
    public void CreatePickupWorks()
    {
        // получим список складов
        var whouses = TestClient.GetWarehouseList();
        var stationId = whouses.Warehouses.Last().StationId; // TestPlatform1;

        // получим допустимые даты и интервалы доставки
        var options = TestClient.GetPickupOptions(stationId);
        Assert.That(options?.PickupOptions, Is.Not.Null.And.Not.Empty);

        // пытаемся создать отгрузку на последний незанятый интервал
        var option = options.PickupOptions.Last();
        var date = option.PickupLocalDate;
        var interval = option.PickupLocalTimeIntervals.Last();

        // создаем отгрузку — почти всегда говорит, что слот кем-то занят
        var pickupId = TestClient.CreatePickup(new CreatePickupRequest
        {
            StationId = TestPlatform1,
            PickupLocalDate = date,
            PickupLocalTimeInterval = interval,
            Parameters = new PickupParameters
            {
                VolumeM3 = "0.5",
                WeightG = 100,
                Requirements = new PickupRequirements
                {
                    LoadersRequired = false,
                }
            }
        });

        Assert.That(pickupId, Is.Not.Null.And.Not.Empty);
    }

    [Test] [Ignore("Pickup has status cancelled, it cannot be cancelled")]
    public void CancelPickupWorks()
    {
        // один раз для этого pickupId сработало, повторно не дает
        TestClient.CancelPickup("019d2190-0d90-7272-ba96-8eef1d8231db");
    }

    [Test]
    public void TryCreateThenCancelAndRecreatePickupWorks()
    {
        // получим допустимые даты и интервалы доставки
        var options = TestClient.GetPickupOptions(TestPlatform1);
        Assert.That(options?.PickupOptions, Is.Not.Null.And.Not.Empty);

        // пытаемся создать отгрузку на первый незанятый интервал
        var option = options.PickupOptions.First();
        var date = option.PickupLocalDate;
        var interval = option.PickupLocalTimeIntervals.Last();
        var request = new CreatePickupRequest
        {
            StationId = TestPlatform1,
            PickupLocalDate = date,
            PickupLocalTimeInterval = interval,
            Parameters = new PickupParameters
            {
                VolumeM3 = "0.5",
                WeightG = 100,
                Requirements = new PickupRequirements
                {
                    LoadersRequired = false,
                }
            }
        };

        try
        {
            // создаем отгрузку — может сообщить, что слот кем-то занят
            var pickupId = TestClient.CreatePickup(request);
            Assert.That(pickupId, Is.Not.Null.And.Not.Empty);

            // удача: получилось с первого раза
            TestContext.Out.WriteLine($"Woohoo! Created pickup: {pickupId}");
        }
        catch (YandexDeliveryException ex)
        {
            // конфликт: на тестовом контуре уже есть чья-то отгрузка на этот временной слот
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
            Assert.That(ex.ErrorInfo, Is.Not.Null);
            Assert.That(ex.ErrorInfo.Message, Does.Contain("pickup").And.Contain("already"));

            // костыль: из сообщения ...pickup XXXX already exists... вырежем XXXX
            var pickupId = ex.ErrorInfo.Message;
            pickupId = pickupId.Substring(pickupId.IndexOf("pickup") + 7);
            pickupId = pickupId.Substring(0, pickupId.IndexOf("already")).Trim();
            TestContext.Out.WriteLine($"Trying to cancel pickup: '{pickupId}'...");

            // отменяем чужую конфликтующую отгрузку
            TestClient.CancelPickup(pickupId);

            // пересоздаем отгрузку — теперь все должно пройти
            pickupId = TestClient.CreatePickup(request);
            TestContext.Out.WriteLine($"At last! Re-created pickup: {pickupId}");
        }
    }
}