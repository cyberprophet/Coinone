using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Coinone.Models;

public class Ticker : StreamTicker
{
    /// <summary>매도 최저가의 오더북 정보</summary>
    [DataMember, JsonProperty("best_asks"), JsonPropertyName("best_asks")]
    public BestOrderBook[]? BestAsks
    {
        get; set;
    }

    /// <summary>매수 최고가의 오더북 정보</summary>
    [DataMember, JsonProperty("best_bids"), JsonPropertyName("best_bids")]
    public BestOrderBook[]? BestBids
    {
        get; set;
    }
}