using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models.Filters;

public class MaxNumIcebergOrdersFilter : Filter
{
    [DataMember, JsonProperty("maxNumIcebergOrders"), JsonPropertyName("maxNumIcebergOrders")]
    public int MaxNumIcebergOrders
    {
        get; set;
    }
    /*{
  "filterType": "",
  "": 5
}*/
}