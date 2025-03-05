# [![NuGet](https://img.shields.io/nuget/v/ShareInvest.Coinone?label=ShareInvest.Coinone&style=plastic&logo=nuget&color=004880)](https://www.nuget.org/packages/ShareInvest.Coinone)
```C#
using Newtonsoft.Json;

using ShareInvest.Coinone;
using ShareInvest.Coinone.Models;

IEnumerable<Ticker> tickers;

using (var api = new Quotation())
{
    var market = await api.GetMarketAsync();

    var response = await api.GetTickerAsync(true);

    tickers = response?.Tickers;

    foreach (var ticker in tickers)
    {
        Console.WriteLine(ticker.Code);
    }
}

using (var socket = new WebSocket())
{
    socket.SendTicker += (sender, e) =>
    {
        Console.WriteLine(JsonConvert.SerializeObject(e.Ticker, Formatting.Indented));
    };
    await socket.ConnectAsync();

    var task = Task.Run(socket.ReceiveAsync);

    await socket.RequestPingAsync();

    foreach (var ticker in tickers)
    {
        await socket.RequestAsync("SUBSCRIBE", "TICKER", "KRW", ticker.Code.ToUpperInvariant());
    }
    await task;
}
```
