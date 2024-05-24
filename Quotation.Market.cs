using Newtonsoft.Json;

using RestSharp;

using ShareInvest.Binance.Converters;
using ShareInvest.Binance.Models;

using System.Net;

namespace ShareInvest.Binance;

public partial class Quotation
{
    public override async Task<RestResponse> GetMarketAsync(bool exchangeInfo = true)
    {
        return await ExecuteAsync(new RestRequest(nameof(exchangeInfo)), cts.Token);
    }

    public async Task<ExchangeInfo?> GetMarketAsync()
    {
        var response = await GetMarketAsync(true);

        return deserializeContent(response);
    }

    public async Task<ExchangeInfo?> GetMarketAsync(string[]? permissions = null, params string[] symbols)
    {
        if (symbols.Length == 1)
        {
            var res = await GetMarketAsync(symbols[0], permissions: permissions ?? []);

            return res;
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

        return JsonConvert.DeserializeObject<ExchangeInfo>(res.Content, new JsonSerializerSettings
        {
            Converters = new[] { new FilterConverter() }
        });
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
}