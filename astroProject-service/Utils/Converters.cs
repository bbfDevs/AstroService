using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace astroProject_service.Utils
{
    public class Converters
    {
        public class DateTimeConverter : JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return DateTime.Parse(reader.GetString(), CultureInfo.InvariantCulture);
            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(DateTime.SpecifyKind(value, DateTimeKind.Local));
            }
        }
    }
}
