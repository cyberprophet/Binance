using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models.Filters;

public class NotionalFilter : Filter
{
    [DataMember, JsonProperty("minNotional"), JsonPropertyName("minNotional")]
    public double MinNotional
    {
        get; set;
    }

    [DataMember, JsonProperty("applyMinToMarket"), JsonPropertyName("applyMinToMarket")]
    public bool ApplyMinToMarket
    {
        get; set;
    }

    [DataMember, JsonProperty("maxNotional"), JsonPropertyName("maxNotional")]
    public double MaxNotional
    {
        get; set;
    }

    [DataMember, JsonProperty("applyMaxToMarket"), JsonPropertyName("applyMaxToMarket")]
    public bool ApplyMaxToMarket
    {
        get; set;
    }

    [DataMember, JsonProperty("avgPriceMins"), JsonPropertyName("avgPriceMins")]
    public int AvgPriceMins
    {
        get; set;
    }
}