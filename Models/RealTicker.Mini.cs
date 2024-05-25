using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models;

public class RealMiniTicker
{
    [DataMember, JsonProperty("e"), JsonPropertyName("eventType")]
    public string? EventType
    {
        get; set;
    }

    [DataMember, JsonProperty("E"), JsonPropertyName("eventTime")]
    public long EventTime
    {
        get; set;
    }

    /// <summary>Symbol</summary>
    [DataMember, JsonProperty("s"), JsonPropertyName("symbol")]
    public string? Code
    {
        get; set;
    }

    [DataMember, JsonProperty("c"), JsonPropertyName("closePrice")]
    public string? ClosePrice
    {
        get; set;
    }

    [DataMember, JsonProperty("o"), JsonPropertyName("openPrice")]
    public string? OpenPrice
    {
        get; set;
    }

    [DataMember, JsonProperty("h"), JsonPropertyName("highPrice")]
    public string? HighPrice
    {
        get; set;
    }

    [DataMember, JsonProperty("l"), JsonPropertyName("lowPrice")]
    public string? LowPrice
    {
        get; set;
    }

    /// <summary>Total traded base asset volume</summary>
    [DataMember, JsonProperty("v"), JsonPropertyName("baseAssetVolume")]
    public string? BaseAssetVolume
    {
        get; set;
    }

    /// <summary>Total traded quote asset volume</summary>
    [DataMember, JsonProperty("q"), JsonPropertyName("quoteAssetVolume")]
    public string? QuoteAssetVolume
    {
        get; set;
    }
}