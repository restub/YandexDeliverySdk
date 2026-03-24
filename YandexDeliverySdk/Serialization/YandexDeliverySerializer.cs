using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Restub.Toolbox;

namespace YandexDeliverySdk.Serialization;

public class YandexDeliverySerializer : NewtonsoftSerializer
{
    protected override JsonSerializerSettings CreateJsonSerializerSettings()
    {
        var settings = base.CreateJsonSerializerSettings();

        // remove default DateTime converters
        foreach (var conv in settings.Converters.OfType<IsoDateTimeConverter>().ToArray())
        {
            settings.Converters.Remove(conv);
        }

        settings.Converters.Add(new FlexibleDateTimeConverter
        {
            // for DateTimeFormats list — use default values
            DateTimeFormat = @"yyyy-MM-dd\THH:mm:sszzzz",
            DateTimeStyles = DateTimeStyles.AllowWhiteSpaces,
        });

        return settings;
    }
}
