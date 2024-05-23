using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShareInvest.Binance;

public enum FilterTypes
{
    PRICE_FILTER,
    PERCENT_PRICE,
    PERCENT_PRICE_BY_SIDE,
    LOT_SIZE,
    MIN_NOTIONAL,
    NOTIONAL,
    ICEBERG_PARTS,
    MARKET_LOT_SIZE,
    MAX_NUM_ORDERS,
    MAX_NUM_ALGO_ORDERS,
    MAX_NUM_ICEBERG_ORDERS,
    MAX_POSITION,
    TRAILING_DELTA
}

public enum Interval
{
    SECOND,
    MINUTE,
    DAY
}

public enum RateLimitType
{
    RAW_REQUESTS,
    REQUEST_WEIGHT,
    ORDERS
}

public enum OrderTypes
{
    LIMIT,
    LIMIT_MAKER,
    MARKET,
    STOP_LOSS,
    STOP_LOSS_LIMIT,
    TAKE_PROFIT,
    TAKE_PROFIT_LIMIT
}

public enum PermissionSets
{
    SPOT,
    MARGIN
}

public enum AllowedSelfTradePreventionModes
{
    NONE,
    EXPIRE_TAKER,
    EXPIRE_MAKER,
    EXPIRE_BOTH
}

[JsonConverter(typeof(StringEnumConverter))]
public enum Permissions
{
    SPOT,
    MARGIN,
    LEVERAGED,
    TRD_GRP_002,
    TRD_GRP_003,
    TRD_GRP_004,
    TRD_GRP_005,
    TRD_GRP_006,
    TRD_GRP_007,
    TRD_GRP_008,
    TRD_GRP_009,
    TRD_GRP_010,
    TRD_GRP_011,
    TRD_GRP_012,
    TRD_GRP_013,
    TRD_GRP_014,
    TRD_GRP_015,
    TRD_GRP_016,
    TRD_GRP_017,
    TRD_GRP_018,
    TRD_GRP_019,
    TRD_GRP_020,
    TRD_GRP_021,
    TRD_GRP_022,
    TRD_GRP_023,
    TRD_GRP_024,
    TRD_GRP_025
}