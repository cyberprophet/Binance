using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models.Filters;

public class IcebergPartsFilter : Filter
{
    [DataMember, JsonProperty("limit"), JsonPropertyName("limit")]
    public int Limit
    {
        get; set;
    }
}