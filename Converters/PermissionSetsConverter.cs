using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShareInvest.Binance.Converters;

public class PermissionSetsConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(List<List<Permissions>>);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        JArray array = JArray.Load(reader);

        var result = new List<List<Permissions>>();

        foreach (var innerArray in array)
        {
            var permissionsList = new List<Permissions>();

            foreach (var item in innerArray)
            {
                permissionsList.Add(item.ToObject<Permissions>());
            }
            result.Add(permissionsList);
        }

        return result;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value == null)
        {
            return;
        }
        var list = (List<List<Permissions>>)value;

        writer.WriteStartArray();

        foreach (var innerList in list)
        {
            writer.WriteStartArray();

            foreach (var permission in innerList)
            {
                writer.WriteValue(permission.ToString());
            }
            writer.WriteEndArray();
        }
        writer.WriteEndArray();
    }
}