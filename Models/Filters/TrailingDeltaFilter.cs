using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models.Filters;

public class TrailingDeltaFilter : Filter
{
    [DataMember, JsonProperty("minTrailingAboveDelta"), JsonPropertyName("minTrailingAboveDelta")]
    public int MinTrailingAboveDelta
    {
        get; set;
    }

    [DataMember, JsonProperty("maxTrailingAboveDelta"), JsonPropertyName("maxTrailingAboveDelta")]
    public int MaxTrailingAboveDelta
    {
        get; set;
    }

    [DataMember, JsonProperty("minTrailingBelowDelta"), JsonPropertyName("minTrailingBelowDelta")]
    public int MinTrailingBelowDelta
    {
        get; set;
    }

    [DataMember, JsonProperty("maxTrailingBelowDelta"), JsonPropertyName("maxTrailingBelowDelta")]
    public int MaxTrailingBelowDelta
    {
        get; set;
    }
}