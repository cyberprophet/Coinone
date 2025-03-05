using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ShareInvest.Coinone.EventHandler;
using ShareInvest.Crypto;

using System.Net.WebSockets;
using System.Text;

namespace ShareInvest.Coinone;

public class WebSocket : ShareWebSocket<TickerEventArgs>
{
    public WebSocket() : base("stream.coinone.co.kr")
    {

    }

    public async Task RequestPingAsync()
    {
        await base.RequestAsync(JsonConvert.SerializeObject(new
        {
            request_type = "PING"
        }));
    }

    /// <summary>웹소켓 요청 방법 topic: quote_currency, target_currency 등의 정보를 JSON 형식으로 입력</summary>
    /// <param name="requestType">실행할 요청 종류: SUBSCRIBE / UNSUBSCRIBE / PING</param>
    /// <param name="channel">구독 채널명: ORDERBOOK / TICKER / TRADE</param>
    /// <param name="quoteCurrency">마켓 기준 통화</param>
    /// <param name="targetCurrency">조회 요청할 종목</param>
    /// <param name="format">단축 변수명으로 구독 원하는 경우 SHORT 입력(기본값 : DEFAULT)</param>
    public async Task RequestAsync(string requestType, string channel, string quoteCurrency, string targetCurrency, string? format = null)
    {
        object value;

        if (string.IsNullOrEmpty(format))
        {
            value = new
            {
                request_type = requestType,
                topic = new
                {
                    quote_currency = quoteCurrency,
                    target_currency = targetCurrency
                },
                channel
            };
        }
        else
        {
            value = new
            {
                request_type = requestType,
                topic = new
                {
                    quote_currency = quoteCurrency,
                    target_currency = targetCurrency
                },
                format,
                channel
            };
        }
        await base.RequestAsync(JsonConvert.SerializeObject(value));
    }

    public override async Task RequestAsync(string json)
    {
        await base.RequestAsync(json);
    }

    public override async Task ReceiveAsync()
    {
        while (WebSocketState.Open == Socket.State)
        {
            var buffer = new byte[0x400];

            var res = await Socket.ReceiveAsync(new ArraySegment<byte>(buffer), cts.Token);

            var str = Encoding.UTF8.GetString(buffer, 0, res.Count);

            if (string.IsNullOrEmpty(str))
            {
                continue;
            }
            var jToken = JToken.Parse(str);

            switch (jToken.Value<string>("response_type"))
            {
                case "DATA" when Convert.ToString(jToken["data"]) is string json:
                    OnReceiveTicker(json);
                    continue;
            }
            Console.WriteLine(jToken);
        }
    }

    public override async Task ConnectAsync(string? token = null, TimeSpan? interval = null)
    {
        await base.ConnectAsync(token, interval: interval ?? TimeSpan.FromMinutes(0x10));
    }

    readonly CancellationTokenSource cts = new();
}