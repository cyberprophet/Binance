using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models;

public abstract class Filter
{
    [DataMember, JsonProperty("filterType"), JsonPropertyName("filterType")]
    public FilterTypes FilterType
    {
        get; set;
    }
}