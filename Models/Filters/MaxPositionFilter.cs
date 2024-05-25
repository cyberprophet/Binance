using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models.Filters;

public class MaxPositionFilter : Filter
{
    [DataMember, JsonProperty("maxPosition"), JsonPropertyName("maxPosition")]
    public double MaxPosition
    {
        get; set;
    }
}