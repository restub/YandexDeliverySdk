using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YandexDeliverySdk.Serialization;

public class FlexibleDateTimeConverter : IsoDateTimeConverter
{
    // Массив форматов, которые нужно поддерживать
    public string[] DateTimeFormats { get; set; } =
    [
        @"yyyy-MM-dd\THH:mm:sszzzz", // дата со временем и часовым поясом
        "yyyy-MM-ddTHH:mm:ss",       // дата со временем
        ShortDateFormat              // только дата
    ];

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        // Если текущее значение в JSON — строка
        if (reader.TokenType == JsonToken.String)
        {
            string dateStr = (string)reader.Value;

            // Пытаемся распарсить строку одним из форматов
            if (DateTime.TryParseExact(dateStr, DateTimeFormats,
                CultureInfo.InvariantCulture, DateTimeStyles, out DateTime result))
            {
                return result;
            }
        }

        // Если строка не подошла под наши форматы,
        // или значение пришло в другом виде (например, уже датой),
        // вызываем стандартную логику базового конвертера.
        return base.ReadJson(reader, objectType, existingValue, serializer);
    }

    public const string ShortDateFormat = "yyyy-MM-dd";

    public static string FormatShortDate(DateTime shortDate) =>
        shortDate.ToString(ShortDateFormat);

    public static DateTime ParseShortDate(string shortDate) =>
        DateTime.ParseExact(shortDate, ShortDateFormat, CultureInfo.InvariantCulture);
}
