using Newtonsoft.Json;

using ShareInvest.Binance.Models;

namespace ShareInvest.Binance.EventHandler;

public class TickerEventArgs(string json) : EventArgs
{
    public RealTicker? Ticker
    {
        get;
    }
        = JsonConvert.DeserializeObject<RealTicker>(json);
}