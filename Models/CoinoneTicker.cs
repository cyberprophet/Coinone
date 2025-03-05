using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Coinone.Models;

public class CoinoneTicker
{
    [DataMember, JsonProperty("result"), JsonPropertyName("result")]
    public string? Result
    {
        get; set;
    }

    [DataMember, JsonProperty("error_code"), JsonPropertyName("error_code")]
    public string? ErrorCode
    {
        get; set;
    }

    [DataMember, JsonProperty("server_time"), JsonPropertyName("server_time")]
    public long ServerTime
    {
        get; set;
    }

    [DataMember, JsonProperty("tickers"), JsonPropertyName("tickers")]
    public Ticker[]? Tickers
    {
        get; set;
    }
}