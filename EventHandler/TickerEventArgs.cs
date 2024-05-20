using Newtonsoft.Json;

using ShareInvest.Coinone.Models;

namespace ShareInvest.Coinone.EventHandler;

public class TickerEventArgs(string json) : EventArgs
{
    public StreamTicker? Ticker
    {
        get;
    }
        = JsonConvert.DeserializeObject<StreamTicker>(json);
}