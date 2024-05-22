using Newtonsoft.Json;

using RestSharp;

using ShareInvest.Binance.Models;
using ShareInvest.Crypto;

using System.Net;
using System.Text;

namespace ShareInvest.Binance;

/// <summary>
/// default Url: https://data-api.binance.vision/api/v3
/// </summary>
/// <param name="baseUrl">
/// https://api.binance.com or
/// https://api-gcp.binance.com or
/// https://api1.binance.com or
/// https://api2.binance.com or
/// https://api3.binance.com or
/// https://api4.binance.com
/// </param>
public class Quotation(string? baseUrl = null) : ShareQuotation(string.IsNullOrEmpty(baseUrl) ? "https://data-api.binance.vision/api/v3" : baseUrl)
{
    public override async Task<RestResponse> GetMarketAsync(bool exchangeInfo = true)
    {
        return await ExecuteAsync(new RestRequest(nameof(exchangeInfo)), cts.Token);
    }

    public async Task<ExchangeInfo[]?> GetMarketAsync()
    {
        return deserializeContent(await GetMarketAsync(true));
    }

    public async Task<ExchangeInfo[]?> GetMarketAsync(string[]? permissions = null, params string[] symbols)
    {
        if (symbols.Length == 1)
        {
            var res = await GetMarketAsync(symbols[0], permissions: permissions ?? []);

            return res != null ? [res] : [];
        }

        if (symbols.Length == 0)
        {
            return null;
        }

        var resource = $"exchangeInfo?{nameof(symbols)}={makeStrArrQuery(symbols)}";

        if (permissions?.Length > 0)
        {
            resource = RebuildQuery(resource, permissions);
        }

        return deserializeContent(await ExecuteAsync(new RestRequest(resource), cts.Token));
    }

    public async Task<ExchangeInfo?> GetMarketAsync(string symbol, params string[]? permissions)
    {
        var res = await ExecuteAsync(new RestRequest(RebuildQuery($"exchangeInfo?{nameof(symbol)}={symbol}", permissions)), cts.Token);

        if (HttpStatusCode.OK != res.StatusCode || string.IsNullOrEmpty(res.Content))
        {
            return null;
        }

        return JsonConvert.DeserializeObject<ExchangeInfo>(res.Content);
    }

    string RebuildQuery(string resource, string[]? permissions)
    {
        if (permissions == null || permissions.Length == 0)
        {
            return resource;
        }

        resource = string.Concat(resource, '&', nameof(permissions), '=');

        if (permissions.Length > 1)
        {
            return string.Concat(resource, makeStrArrQuery(permissions));
        }

        return string.Concat(resource, permissions[0]);
    }

    readonly Func<RestResponse, ExchangeInfo[]?> deserializeContent = res =>
    {
        return HttpStatusCode.OK == res.StatusCode && !string.IsNullOrEmpty(res.Content) ?

            JsonConvert.DeserializeObject<ExchangeInfo[]>(res.Content) : null;
    };

    readonly Func<string[], StringBuilder> makeStrArrQuery = args =>
    {
        StringBuilder sb = new('[');

        for (int index = 0; index < args.Length; index++)
        {
            sb.Append(args[index]);

            if (index == args.Length - 1)
            {
                sb.Append(']');

                break;
            }
            sb.Append(',');
        }

        return sb;
    };

    readonly CancellationTokenSource cts = new();
}