using ShareInvest.Binance.EventHandler;
using ShareInvest.Crypto;

using System.Net.WebSockets;

namespace ShareInvest.Binance;

/// <summary>
/// default Url: data-stream.binance.vision/ws
/// </summary>
/// <param name="baseUrl">
/// stream.binance.com:9443/ws or stream.binance.com/ws
/// </param>
public class WebSocket(string? baseUrl = null) : ShareWebSocket<TickerEventArgs>(string.IsNullOrEmpty(baseUrl) ? "data-stream.binance.vision/ws" : baseUrl)
{
    public override async Task ReceiveAsync()
    {
        while (WebSocketState.Open == Socket.State)
        {

        }
    }

    public override async Task ConnectAsync(string? token = null, TimeSpan? interval = null)
    {
        await base.ConnectAsync(token, interval: interval ?? TimeSpan.FromMinutes(3));
    }
}