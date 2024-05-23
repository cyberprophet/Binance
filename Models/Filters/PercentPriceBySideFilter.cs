using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models.Filters;

public class PercentPriceBySideFilter : Filter
{
    [DataMember, JsonProperty("bidMultiplierUp"), JsonPropertyName("bidMultiplierUp")]
    public double BidMultiplierUp
    {
        get; set;
    }

    [DataMember, JsonProperty("bidMultiplierDown"), JsonPropertyName("bidMultiplierDown")]
    public double BidMultiplierDown
    {
        get; set;
    }

    [DataMember, JsonProperty("askMultiplierUp"), JsonPropertyName("askMultiplierUp")]
    public double AskMultiplierUp
    {
        get; set;
    }

    [DataMember, JsonProperty("askMultiplierDown"), JsonPropertyName("askMultiplierDown")]
    public double AskMultiplierDown
    {
        get; set;
    }

    [DataMember, JsonProperty("avgPriceMins"), JsonPropertyName("avgPriceMins")]
    public int AvgPriceMins
    {
        get; set;
    }
}