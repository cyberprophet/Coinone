using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Coinone.Models;

public class CoinoneMarket
{
    /// <summary>정상 반환 시 success, 에러 코드 반환 시 error</summary>
    [DataMember, JsonProperty("result"), JsonPropertyName("result")]
    public string? Result
    {
        get; set;
    }

    /// <summary>error 발생 시 에러코드 반환, 성공인 경우 0 반환</summary>
    [DataMember, JsonProperty("error_code"), JsonPropertyName("error_code")]
    public string? ErrorCode
    {
        get; set;
    }

    /// <summary>반환 시점의 서버 시간 (ms)</summary>
    [DataMember, JsonProperty("server_time"), JsonPropertyName("server_time")]
    public long ServerTime
    {
        get; set;
    }

    /// <summary>반환하는 종목 정보 배열</summary>
    [DataMember, JsonProperty("currencies"), JsonPropertyName("currencies")]
    public Market[]? Currencies
    {
        get; set;
    }
}