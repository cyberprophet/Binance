using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models.Filters;

public class MaxNumOrdersFilter : Filter
{
    [DataMember, JsonProperty("maxNumOrders"), JsonPropertyName("maxNumOrders")]
    public int MaxNumOrders
    {
        get; set;
    }
}