using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ShareInvest.Binance.Models;
using ShareInvest.Binance.Models.Filters;

namespace ShareInvest.Binance.Converters;

public class FilterConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Filter);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);
        var filterType = jsonObject["filterType"]?.ToObject<FilterTypes>();

        Filter filter = filterType switch
        {
            FilterTypes.PRICE_FILTER => new PriceFilter(),
            FilterTypes.PERCENT_PRICE => new PercentPriceFilter(),
            FilterTypes.PERCENT_PRICE_BY_SIDE => new PercentPriceBySideFilter(),
            FilterTypes.LOT_SIZE => new LotSizeFilter(),
            FilterTypes.MIN_NOTIONAL => new MinNotionalFilter(),
            FilterTypes.NOTIONAL => new NotionalFilter(),
            FilterTypes.ICEBERG_PARTS => new IcebergPartsFilter(),
            FilterTypes.MARKET_LOT_SIZE => new MarketLotSizeFilter(),
            FilterTypes.MAX_NUM_ORDERS => new MaxNumOrdersFilter(),
            FilterTypes.MAX_NUM_ALGO_ORDERS => new MaxNumAlgoOrdersFilter(),
            FilterTypes.MAX_NUM_ICEBERG_ORDERS => new MaxNumIcebergOrdersFilter(),
            FilterTypes.MAX_POSITION => new MaxPositionFilter(),
            FilterTypes.TRAILING_DELTA => new TrailingDeltaFilter(),

            _ => throw new NotSupportedException($"filter type {filterType} is not supported.")
        };
        serializer.Populate(jsonObject.CreateReader(), filter);

        return filter;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}