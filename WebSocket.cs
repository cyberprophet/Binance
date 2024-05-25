using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ShareInvest.Binance.EventHandler;
using ShareInvest.Crypto;

using System.Net.WebSockets;
using System.Text;

namespace ShareInvest.Binance;

/// <summary>
/// default Url: data-stream.binance.vision/ws
/// </summary>
/// <param name="baseUrl">
/// stream.binance.com:9443/ws or stream.binance.com/ws
/// </param>
public class WebSocket(string? baseUrl = null) : ShareWebSocket<TickerEventArgs>(string.IsNullOrEmpty(baseUrl) ? "data-stream.binance.vision/ws" : baseUrl)
{
    /// <param name="method">
    /// Stream Name: \<symbol>@aggTrade
    /// The Aggregate Trade Streams push trade information that is aggregated for a single taker order.
    /// 
    /// Stream Name: \<symbol>@trade
    /// The Trade Streams push raw trade information; each trade has a unique buyer and seller.
    /// 
    /// Stream Name: \<symbol>@kline_\<interval>
    /// The Kline/Candlestick Stream push updates to the current klines/candlestick every second.
    /// 
    /// Stream Name: \<symbol>@miniTicker
    /// 24hr rolling window mini-ticker statistics.
    /// These are NOT the statistics of the UTC day, but a 24hr rolling window for the previous 24hrs.
    /// 
    /// Stream Name: !miniTicker@arr
    /// 24hr rolling window mini-ticker statistics for all symbols that changed in an array.
    /// These are NOT the statistics of the UTC day, but a 24hr rolling window for the previous 24hrs.
    /// Note that only tickers that have changed will be present in the array.
    /// 
    /// Stream Name: \<symbol>@ticker
    /// 24hr rolling window ticker statistics for a single symbol.
    /// These are NOT the statistics of the UTC day, but a 24hr rolling window for the previous 24hrs.
    /// 
    /// Stream Name: !ticker@arr
    /// 24hr rolling window ticker statistics for all symbols that changed in an array.
    /// These are NOT the statistics of the UTC day, but a 24hr rolling window for the previous 24hrs.
    /// Note that only tickers that have changed will be present in the array.
    /// 
    /// Stream Name: \<symbol>@ticker_\<window_size>
    /// Rolling window ticker statistics for a single symbol, computed over multiple windows.
    /// 
    /// Stream Name: !ticker_\<window-size>@arr
    /// Rolling window ticker statistics for all market symbols, computed over multiple windows.
    /// Note that only tickers that have changed will be present in the array.
    /// 
    /// Stream Name: \<symbol>@bookTicker
    /// Pushes any update to the best bid or ask's price or quantity in real-time for a specified symbol.
    /// Multiple <symbol>@bookTicker streams can be subscribed to over one connection.
    /// 
    /// Stream Name: \<symbol>@avgPrice
    /// Average price streams push changes in the average price over a fixed time interval.
    /// 
    /// Stream Names: \<symbol>@depth\<levels> OR \<symbol>@depth\<levels>@100ms
    /// Top \<levels> bids and asks, pushed every second. Valid \<levels> are 5, 10, or 20.
    /// 
    /// Stream Name: \<symbol>@depth OR \<symbol>@depth@100ms
    /// Order book price and quantity depth updates used to locally manage an order book.
    /// </param>
    /// <param name="param">[
    /// "btcusdt@aggTrade",
    /// "btcusdt@depth",
    /// true
    /// ]</param>
    public async Task RequestAsync(string method, params object[] @params)
    {
        var json = JsonConvert.SerializeObject(new
        {
            method,
            @params,
            id = id++
        });
        await base.RequestAsync(json);
    }

    public override async Task RequestAsync(string json)
    {
        await base.RequestAsync(json);
    }

    public override async Task ReceiveAsync()
    {
        while (WebSocketState.Open == Socket.State)
        {
            var buffer = new byte[0x400 * 0x400];

            var res = await Socket.ReceiveAsync(new ArraySegment<byte>(buffer), cts.Token);

            var str = Encoding.UTF8.GetString(buffer, 0, res.Count);

            if (string.IsNullOrEmpty(str))
            {
                continue;
            }

            if (str.Length < 0x100)
            {
                Console.WriteLine(new
                {
                    CryptoExchange = nameof(Binance),
                    DateTime.Now,
                    Response = JToken.Parse(str)
                });
                continue;
            }

            foreach (var jToken in JArray.Parse(str))
            {
                switch (jToken.Value<string>("e"))
                {
                    case "24hrTicker":
                        OnReceiveTicker(jToken.ToString());
                        continue;
                }
            }
        }

        Console.WriteLine(new
        {
            CryptoExchange = nameof(Binance),
            DateTime.Now,
            Socket = Socket.State
        });
    }

    public override async Task ConnectAsync(string? token = null, TimeSpan? interval = null)
    {
        await base.ConnectAsync(token, interval: interval ?? TimeSpan.FromMinutes(3));
    }

    readonly CancellationTokenSource cts = new();

    int id = 1;
}