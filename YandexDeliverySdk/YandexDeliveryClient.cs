using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Restub;

namespace YandexDeliverySdk;

public partial class YandexDeliveryClient : RestubClient, IAuthenticator
{
	// параметры доставки на следующий день
	// https://yandex.com/support/delivery-profile/ru/api/other-day/access
	public const string Api = "api/b2b/platform/";
	public const string TestUrl = "https://b2b.taxi.tst.yandex.net/";
	public const string MainUrl = "https://b2b-authproxy.taxi.yandex.net/";
	public const string TestToken = "y2_AgAAAAD04omrAAAPeAAAAAACRpC94Qk6Z5rUTgOcTgYFECJllXYKFx8";

	// тестовые склады и ПВЗ, platform_station_id
	public const string TestPlatform1 = "fbed3aa1-2cc6-4370-ab4d-59c5cc9bb924";
	public const string TestPlatform2 = "e1139f6d-e34f-47a9-a55f-31f032a861a6"; // Откуда: Москва Ленинградский проспект 27
	public const string TestPlatform3 = "01946f4f013c7337874ec2fb848a58a4"; // Куда: Москва Ленинградский проспект 37 к9

	public YandexDeliveryClient(string baseUrl = TestUrl, string token = TestToken)
		: base(baseUrl + Api)
	{
		Token = token;
	}

	public string Token { get; set; }

	public void Authenticate(IRestClient client, IRestRequest request)
	{
		request.AddHeader("Authorization", "Bearer " + Token);
		request.AddHeader("Accept-Language", "ru");
	}
}
