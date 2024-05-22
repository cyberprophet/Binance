namespace ShareInvest.Binance.EventHandler;

public class TickerEventArgs : EventArgs
{
    public object Ticker
    {
        get;
    }

    public TickerEventArgs()
    {

    }
}