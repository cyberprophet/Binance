using Newtonsoft.Json;

using ShareInvest.Binance.Converters;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Binance.Models;

public class Market
{
    [DataMember, JsonProperty("symbol"), JsonPropertyName("symbol")]
    public string? Code
    {
        get; set;
    }

    [DataMember, JsonProperty("status"), JsonPropertyName("status")]
    public string? Status
    {
        get; set;
    }

    [DataMember, JsonProperty("baseAsset"), JsonPropertyName("baseAsset")]
    public string? BaseAsset
    {
        get; set;
    }

    [DataMember, JsonProperty("baseAssetPrecision"), JsonPropertyName("baseAssetPrecision")]
    public int BaseAssetPrecision
    {
        get; set;
    }

    [DataMember, JsonProperty("quoteAsset"), JsonPropertyName("quoteAsset")]
    public string? QuoteAsset
    {
        get; set;
    }

    /// <summary>will be removed in future api versions (v4+)</summary>
    [DataMember, JsonProperty("quotePrecision"), JsonPropertyName("quotePrecision")]
    public int QuotePrecision
    {
        get; set;
    }

    [DataMember, JsonProperty("quoteAssetPrecision"), JsonPropertyName("quoteAssetPrecision")]
    public int QuoteAssetPrecision
    {
        get; set;
    }

    [DataMember, JsonProperty("baseCommissionPrecision"), JsonPropertyName("baseCommissionPrecision")]
    public int BaseCommissionPrecision
    {
        get; set;
    }

    [DataMember, JsonProperty("quoteCommissionPrecision"), JsonPropertyName("quoteCommissionPrecision")]
    public int QuoteCommissionPrecision
    {
        get; set;
    }

    [DataMember, JsonProperty("icebergAllowed"), JsonPropertyName("icebergAllowed")]
    public bool IcebergAllowed
    {
        get; set;
    }

    [DataMember, JsonProperty("ocoAllowed"), JsonPropertyName("ocoAllowed")]
    public bool OcoAllowed
    {
        get; set;
    }

    [DataMember, JsonProperty("quoteOrderQtyMarketAllowed"), JsonPropertyName("quoteOrderQtyMarketAllowed")]
    public bool QuoteOrderQtyMarketAllowed
    {
        get; set;
    }

    [DataMember, JsonProperty("allowTrailingStop"), JsonPropertyName("allowTrailingStop")]
    public bool AllowTrailingStop
    {
        get; set;
    }

    [DataMember, JsonProperty("cancelReplaceAllowed"), JsonPropertyName("cancelReplaceAllowed")]
    public bool CancelReplaceAllowed
    {
        get; set;
    }

    [DataMember, JsonProperty("isSpotTradingAllowed"), JsonPropertyName("isSpotTradingAllowed")]
    public bool IsSpotTradingAllowed
    {
        get; set;
    }

    [DataMember, JsonProperty("isMarginTradingAllowed"), JsonPropertyName("isMarginTradingAllowed")]
    public bool IsMarginTradingAllowed
    {
        get; set;
    }

    [DataMember, JsonProperty("defaultSelfTradePreventionMode"), JsonPropertyName("defaultSelfTradePreventionMode")]
    public AllowedSelfTradePreventionModes DefaultSelfTradePreventionMode
    {
        get; set;
    }

    [DataMember, JsonProperty("orderTypes"), JsonPropertyName("orderTypes")]
    public OrderTypes[]? OrderTypes
    {
        get; set;
    }

    [DataMember, JsonProperty("permissionSets"), JsonPropertyName("permissionSets"), Newtonsoft.Json.JsonConverter(typeof(PermissionSetsConverter))]
    public List<List<Permissions>>? PermissionSets
    {
        get; set;
    }

    [DataMember, JsonProperty("permissions"), JsonPropertyName("permissions")]
    public Permissions[]? Permissions
    {
        get; set;
    }

    [DataMember, JsonProperty("filters"), JsonPropertyName("filters")]
    public List<Filter>? Filters
    {
        get; set;
    }

    [DataMember, JsonProperty("allowedSelfTradePreventionModes"), JsonPropertyName("allowedSelfTradePreventionModes")]
    public AllowedSelfTradePreventionModes[]? AllowedSelfTradePreventionModes
    {
        get; set;
    }
}