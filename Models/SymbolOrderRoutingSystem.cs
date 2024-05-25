using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models;

public class SymbolOrderRoutingSystem
{
    [DataMember, JsonProperty("baseAsset"), JsonPropertyName("baseAsset")]
    public string? BaseAsset
    {
        get; set;
    }

    [DataMember, JsonProperty("symbols"), JsonPropertyName("symbols")]
    public string[]? Symbols
    {
        get; set;
    }
}