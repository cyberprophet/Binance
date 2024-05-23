using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models.Filters;

public class PriceFilter : Filter
{
    [DataMember, JsonProperty("minPrice"), JsonPropertyName("minPrice")]
    public double MinPrice
    {
        get; set;
    }

    [DataMember, JsonProperty("maxPrice"), JsonPropertyName("maxPrice")]
    public double MaxPrice
    {
        get; set;
    }

    [DataMember, JsonProperty("tickSize"), JsonPropertyName("tickSize")]
    public double TickSize
    {
        get; set;
    }
}