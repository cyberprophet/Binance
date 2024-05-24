using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models;

public class MiniTicker
{
    [DataMember, JsonProperty("symbol"), JsonPropertyName("symbol")]
    public string? Code
    {
        get; set;
    }

    [DataMember, JsonProperty("openPrice"), JsonPropertyName("openPrice")]
    public string? OpenPrice
    {
        get; set;
    }

    [DataMember, JsonProperty("highPrice"), JsonPropertyName("highPrice")]
    public string? HighPrice
    {
        get; set;
    }

    [DataMember, JsonProperty("lowPrice"), JsonPropertyName("lowPrice")]
    public string? LowPrice
    {
        get; set;
    }

    [DataMember, JsonProperty("lastPrice"), JsonPropertyName("lastPrice")]
    public string? LastPrice
    {
        get; set;
    }

    [DataMember, JsonProperty("volume"), JsonPropertyName("volume")]
    public string? Volume
    {
        get; set;
    }

    /// <summary>Sum of (price * volume) for all trades</summary>
    [DataMember, JsonProperty("quoteVolume"), JsonPropertyName("quoteVolume")]
    public string? QuoteVolume
    {
        get; set;
    }

    /// <summary>Open time for ticker window</summary>
    [DataMember, JsonProperty("openTime"), JsonPropertyName("openTime")]
    public long OpenTime
    {
        get; set;
    }

    /// <summary>Close time for ticker window</summary>
    [DataMember, JsonProperty("closeTime"), JsonPropertyName("closeTime")]
    public long CloseTime
    {
        get; set;
    }

    /// <summary>Trade IDs</summary>
    [DataMember, JsonProperty("firstId"), JsonPropertyName("firstId")]
    public long FirstId
    {
        get; set;
    }

    [DataMember, JsonProperty("lastId"), JsonPropertyName("lastId")]
    public long LastId
    {
        get; set;
    }

    /// <summary>Number of trades in the interval</summary>
    [DataMember, JsonProperty("count"), JsonPropertyName("count")]
    public long Count
    {
        get; set;
    }
}