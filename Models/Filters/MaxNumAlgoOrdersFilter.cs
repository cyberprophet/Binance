using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models.Filters;

public class MaxNumAlgoOrdersFilter : Filter
{
    [DataMember, JsonProperty("maxNumAlgoOrders"), JsonPropertyName("maxNumAlgoOrders")]
    public int MaxNumAlgoOrders
    {
        get; set;
    }
}