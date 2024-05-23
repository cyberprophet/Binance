using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models.Filters;

public class MinNotionalFilter : Filter
{
    [DataMember, JsonProperty("minNotional"), JsonPropertyName("minNotional")]
    public double MinNotional
    {
        get; set;
    }

    [DataMember, JsonProperty("applyToMarket"), JsonPropertyName("applyToMarket")]
    public bool ApplyToMarket
    {
        get; set;
    }

    [DataMember, JsonProperty("avgPriceMins"), JsonPropertyName("avgPriceMins")]
    public int AvgPriceMins
    {
        get; set;
    }
}