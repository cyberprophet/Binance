using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models;

public class RealTicker : RealMiniTicker
{
    /// <summary>Price change</summary>
    [DataMember, JsonProperty("p"), JsonPropertyName("priceChange")]
    public string? PriceChange
    {
        get; set;
    }

    /// <summary>Price change percent</summary>
    [DataMember, JsonProperty("P"), JsonPropertyName("priceChangePercent")]
    public string? PriceChangePercent
    {
        get; set;
    }

    /// <summary>Weighted average price</summary>
    [DataMember, JsonProperty("w"), JsonPropertyName("weightedAvgPrice")]
    public string? WeightedAvgPrice
    {
        get; set;
    }

    /// <summary>First trade(F)-1 price (first trade before the 24hr rolling window)</summary>
    [DataMember, JsonProperty("x"), JsonPropertyName("firstTradePrice")]
    public string? FirstTradePrice
    {
        get; set;
    }

    /// <summary>Last quantity</summary>
    [DataMember, JsonProperty("Q"), JsonPropertyName("lastQty")]
    public string? LastQty
    {
        get; set;
    }

    /// <summary>Best bid price</summary>
    [DataMember, JsonProperty("b"), JsonPropertyName("bestBidPrice")]
    public string? BestBidPrice
    {
        get; set;
    }

    /// <summary>Best bid quantity</summary>
    [DataMember, JsonProperty("B"), JsonPropertyName("bestBidQty")]
    public string? BestBidQty
    {
        get; set;
    }

    /// <summary>Best ask price</summary>
    [DataMember, JsonProperty("a"), JsonPropertyName("bestAskPrice")]
    public string? BestAskPrice
    {
        get; set;
    }

    /// <summary>Best ask quantity</summary>
    [DataMember, JsonProperty("A"), JsonPropertyName("bestAskQty")]
    public string? BestAskQty
    {
        get; set;
    }

    /// <summary>Statistics open time</summary>
    [DataMember, JsonProperty("O"), JsonPropertyName("openTime")]
    public long StatisticsOpenTime
    {
        get; set;
    }

    /// <summary>Statistics close time</summary>
    [DataMember, JsonProperty("C"), JsonPropertyName("closeTime")]
    public long StatisticsCloseTime
    {
        get; set;
    }

    /// <summary>First trade ID</summary>
    [DataMember, JsonProperty("F"), JsonPropertyName("firstTradeId")]
    public long FirstTradeId
    {
        get; set;
    }

    /// <summary>Total number of trades</summary>
    [DataMember, JsonProperty("n"), JsonPropertyName("totalNumberOfTrades")]
    public long TotalNumberOfTrades
    {
        get; set;
    }

    /// <summary>Last trade ID</summary>
    [DataMember, JsonProperty("L"), JsonPropertyName("lastTradeId")]
    public long LastTradeId
    {
        get; set;
    }
}