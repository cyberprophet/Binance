using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models;

public class Ticker : WindowSizeTicker
{
    [DataMember, JsonProperty("prevClosePrice"), JsonPropertyName("prevClosePrice")]
    public string? PrevClosePrice
    {
        get; set;
    }

    [DataMember, JsonProperty("lastQty"), JsonPropertyName("lastQty")]
    public string? LastQty
    {
        get; set;
    }

    [DataMember, JsonProperty("bidPrice"), JsonPropertyName("bidPrice")]
    public string? BidPrice
    {
        get; set;
    }

    [DataMember, JsonProperty("bidQty"), JsonPropertyName("bidQty")]
    public string? BidQty
    {
        get; set;
    }

    [DataMember, JsonProperty("askPrice"), JsonPropertyName("askPrice")]
    public string? AskPrice
    {
        get; set;
    }

    [DataMember, JsonProperty("askQty"), JsonPropertyName("askQty")]
    public string? AskQty
    {
        get; set;
    }
}