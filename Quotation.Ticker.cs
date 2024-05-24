using Newtonsoft.Json;

using RestSharp;

using ShareInvest.Binance.Models;

using System.Net;

namespace ShareInvest.Binance;

public partial class Quotation
{
    /// <param name="type">
    /// Supported values: FULL or MINI,
    /// Default: FULL
    /// </param>
    public async Task<Ticker[]?> GetEntireDayTickerAsync(string? type = null)
    {
        var response = await Get24hrTickerAsync(type: type);

        if (HttpStatusCode.OK != response.StatusCode || string.IsNullOrEmpty(response.Content))
        {
            return null;
        }

        return JsonConvert.DeserializeObject<Ticker[]>(response.Content);
    }

    /// <param name="type">
    /// Supported values: FULL or MINI,
    /// Default: FULL
    /// </param>
    public async IAsyncEnumerable<Ticker> Get24hrTickerAsync(Market[] markets, string? type = null)
    {
        var symbols = from m in markets.Select((e, index) => new { e.Code, index })
                      group m.Code by m.index / 100 into g
                      select g.ToArray();

        await foreach (var tickers in Get24hrTickerAsync(symbols, type))
        {
            if (tickers != null)
            {
                foreach (var ticker in tickers) yield return ticker;
            }
        }
    }

    /// <param name="type">
    /// Supported values: FULL or MINI,
    /// Default: FULL
    /// </param>
    public async IAsyncEnumerable<Ticker[]?> Get24hrTickerAsync(IEnumerable<string[]> symbols, string? type = null)
    {
        foreach (var symbolArr in symbols)
        {
            var response = await Get24hrTickerAsync(type, symbolArr);

            if (HttpStatusCode.OK != response.StatusCode || string.IsNullOrEmpty(response.Content))
            {
                continue;
            }

            if (symbolArr.Length == 1)
            {
                var ticker = JsonConvert.DeserializeObject<Ticker>(response.Content);

                if (ticker != null)
                {
                    yield return new[] { ticker };
                }

                yield break;
            }

            yield return JsonConvert.DeserializeObject<Ticker[]>(response.Content);
        }
    }

    /// <param name="type">
    /// Supported values: FULL or MINI,
    /// Default: FULL
    /// </param>
    public async Task<RestResponse> Get24hrTickerAsync(string? type = null, params string[] symbol)
    {
        string resource = $"ticker/24hr{symbol.Length switch
        {
            > 1 => $"?symbols={Uri.EscapeDataString(JsonConvert.SerializeObject(symbol.Length > 0x64 ? symbol[..0x64] : symbol))}",

            1 => $"?symbol={symbol}",

            _ => string.Empty
        }}";

        if (string.IsNullOrEmpty(type) is false)
        {
            resource = string.Concat(resource, '&', nameof(type), '=', type);
        }

        return await ExecuteAsync(new RestRequest(resource), cts.Token);
    }

    /// <param name="windowSize">
    /// Minutes: 1m to 59m,
    /// Hours: 1h to 23h,
    /// Days: 1d to 7d,
    /// Example: windowSize=2h (2hours)
    /// </param>
    /// <param name="type">
    /// Supported values: FULL or MINI,
    /// Default: FULL
    /// </param>
    public async IAsyncEnumerable<WindowSizeTicker> GetTickerAsync(Market[] markets, string? windowSize = null, string? type = null)
    {
        var symbols = from m in markets.Select((e, index) => new { e.Code, index })
                      group m.Code by m.index / 100 into g
                      select g.ToArray();

        await foreach (var tickers in GetTickerAsync(symbols, windowSize, type))
        {
            if (tickers != null)
            {
                foreach (var ticker in tickers) yield return ticker;
            }
        }
    }

    /// <param name="windowSize">
    /// Minutes: 1m to 59m,
    /// Hours: 1h to 23h,
    /// Days: 1d to 7d,
    /// Example: windowSize=2h (2hours)
    /// </param>
    /// <param name="type">
    /// Supported values: FULL or MINI,
    /// Default: FULL
    /// </param>
    public async IAsyncEnumerable<WindowSizeTicker[]?> GetTickerAsync(IEnumerable<string[]> symbols, string? windowSize = null, string? type = null)
    {
        foreach (var symbolArr in symbols)
        {
            var response = await GetTickerAsync(windowSize, type, symbolArr);

            if (HttpStatusCode.OK != response.StatusCode || string.IsNullOrEmpty(response.Content))
            {
                continue;
            }

            if (symbolArr.Length == 1)
            {
                var ticker = JsonConvert.DeserializeObject<WindowSizeTicker>(response.Content);

                if (ticker != null)
                {
                    yield return new[] { ticker };
                }

                yield break;
            }

            yield return JsonConvert.DeserializeObject<WindowSizeTicker[]>(response.Content);
        }
    }

    /// <param name="windowSize">
    /// Minutes: 1m to 59m,
    /// Hours: 1h to 23h,
    /// Days: 1d to 7d,
    /// Example: windowSize=2h (2hours)
    /// </param>
    /// <param name="type">
    /// Supported values: FULL or MINI,
    /// Default: FULL
    /// </param>
    public async Task<RestResponse> GetTickerAsync(string? windowSize = null, string? type = null, params string[] symbol)
    {
        string resource = "ticker?";

        if (symbol.Length > 1)
        {
            var symbols = Uri.EscapeDataString(JsonConvert.SerializeObject(symbol.Length > 0x64 ? symbol[..0x64] : symbol));

            resource = string.Concat(resource, nameof(symbols), '=', symbols);
        }
        else
        {
            resource = string.Concat(resource, nameof(symbol), '=', symbol[0]);
        }

        if (string.IsNullOrEmpty(windowSize) is false)
        {
            resource = string.Concat(resource, '&', nameof(windowSize), '=', windowSize);
        }

        if (string.IsNullOrEmpty(type) is false)
        {
            resource = string.Concat(resource, '&', nameof(type), '=', type);
        }

        return await ExecuteAsync(new RestRequest(resource), cts.Token);
    }

    public override async Task<RestResponse> GetTickerAsync(params string[] symbol)
    {
        return await GetTickerAsync(windowSize: null, type: null, symbol);
    }
}