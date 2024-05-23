using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models.Filters;

public class MarketLotSizeFilter : Filter
{
    [DataMember, JsonProperty("minQty"), JsonPropertyName("minQty")]
    public double MinQty
    {
        get; set;
    }

    [DataMember, JsonProperty("maxQty"), JsonPropertyName("maxQty")]
    public double MaxQty
    {
        get; set;
    }

    [DataMember, JsonProperty("stepSize"), JsonPropertyName("stepSize")]
    public double StepSize
    {
        get; set;
    }
}