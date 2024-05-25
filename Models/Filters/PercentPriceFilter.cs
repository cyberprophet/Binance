using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models.Filters;

public class PercentPriceFilter : Filter
{
    [DataMember, JsonProperty("multiplierUp"), JsonPropertyName("multiplierUp")]
    public double MultiplierUp
    {
        get; set;
    }

    [DataMember, JsonProperty("multiplierDown"), JsonPropertyName("multiplierDown")]
    public double MultiplierDown
    {
        get; set;
    }

    [DataMember, JsonProperty("avgPriceMins"), JsonPropertyName("avgPriceMins")]
    public int AvgPriceMins
    {
        get; set;
    }
}