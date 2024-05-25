# [![NuGet](https://img.shields.io/nuget/v/ShareInvest.Binance?label=ShareInvest.Binance&style=plastic&logo=nuget&color=004880)](https://www.nuget.org/packages/ShareInvest.Binance)
```C#
using Newtonsoft.Json;

using ShareInvest.Binance;
using ShareInvest.Binance.Models;

IEnumerable<Ticker> tickers;

using (var api = new Quotation())
{
    tickers = await api.GetEntireDayTickerAsync() ?? [];
}

using (var socket = new WebSocket())
{
    socket.SendTicker += (sender, e) =>
    {
        Console.WriteLine(JsonConvert.SerializeObject(e.Ticker, Formatting.Indented));
    };
    await socket.ConnectAsync();

    var task = Task.Run(socket.ReceiveAsync);

    await socket.RequestAsync("SUBSCRIBE", "!ticker@arr");
    await task;
}
```
