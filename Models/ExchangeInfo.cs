using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models;

public class ExchangeInfo
{
    [DataMember, JsonProperty("timezone"), JsonPropertyName("timezone")]
    public string? Timezone
    {
        get; set;
    }

    [DataMember, JsonProperty("serverTime"), JsonPropertyName("serverTime")]
    public string? ServerTime
    {
        get; set;
    }

    /// <summary>
    /// These are defined in the `ENUM definitions` section under `Rate Limiters (rateLimitType)`.
    /// All limits are optional
    /// </summary>
    [DataMember, JsonProperty("rateLimits"), JsonPropertyName("rateLimits")]
    public RateLimit[]? RateLimits
    {
        get; set;
    }

    /// <summary>
    /// These are the defined filters in the `Filters` section.
    /// All filters are optional.
    /// </summary>
    [DataMember, JsonProperty("exchangeFilters"), JsonPropertyName("exchangeFilters")]
    public List<Filter>? ExchangeFilters
    {
        get; set;
    }

    [DataMember, JsonProperty("symbols"), JsonPropertyName("symbols")]
    public Market[]? Symbols
    {
        get; set;
    }

    [DataMember, JsonProperty("sors"), JsonPropertyName("sors")]
    public SymbolOrderRoutingSystem[]? SymbolOrderRoutingSystem
    {
        get; set;
    }
}