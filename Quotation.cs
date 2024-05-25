using Newtonsoft.Json;

using RestSharp;

using ShareInvest.Binance.Converters;
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
public partial class Quotation(string? baseUrl = null) : ShareQuotation(string.IsNullOrEmpty(baseUrl) ? "https://data-api.binance.vision/api/v3" : baseUrl)
{
    readonly Func<RestResponse, ExchangeInfo?> deserializeContent = res =>
    {
        return HttpStatusCode.OK != res.StatusCode || string.IsNullOrEmpty(res.Content) ? null :

            JsonConvert.DeserializeObject<ExchangeInfo>(res.Content, new JsonSerializerSettings
            {
                Converters = new[] { new FilterConverter() }
            });
    };

    readonly Func<string[], StringBuilder> makeStrArrQuery = args =>
    {
        StringBuilder sb = new("[");

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