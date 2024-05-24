using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models;

public class WindowSizeTicker : MiniTicker
{
    /// <summary>Absolute price change</summary>
    [DataMember, JsonProperty("priceChange"), JsonPropertyName("priceChange")]
    public string? PriceChange
    {
        get; set;
    }

    /// <summary>Relative price change in percent</summary>
    [DataMember, JsonProperty("priceChangePercent"), JsonPropertyName("priceChangePercent")]
    public string? PriceChangePercent
    {
        get; set;
    }

    /// <summary>QuoteVolume / Volume</summary>
    [DataMember, JsonProperty("weightedAvgPrice"), JsonPropertyName("weightedAvgPrice")]
    public string? WeightedAvgPrice
    {
        get; set;
    }
}