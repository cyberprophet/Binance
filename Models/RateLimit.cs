using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models;

public class RateLimit
{
    [DataMember, JsonProperty("rateLimitType"), JsonPropertyName("rateLimitType")]
    public RateLimitType RateLimitType
    {
        get; set;
    }

    [DataMember, JsonProperty("interval"), JsonPropertyName("interval")]
    public Interval Interval
    {
        get; set;
    }

    [DataMember, JsonProperty("intervalNum"), JsonPropertyName("intervalNum")]
    public int IntervalNum
    {
        get; set;
    }

    [DataMember, JsonProperty("limit"), JsonPropertyName("limit")]
    public int Limit
    {
        get; set;
    }
}