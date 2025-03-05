using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Coinone.Models;

public class StreamTicker
{
    /// <summary>티커 종목 명</summary>
    [DataMember, JsonProperty("target_currency"), JsonPropertyName("target_currency"), Key]
    public string? Code
    {
        get; set;
    }

    /// <summary>마켓 기준 통화</summary>
    [DataMember, JsonProperty("quote_currency"), JsonPropertyName("quote_currency")]
    public string? QuoteCurrency
    {
        get; set;
    }

    /// <summary>티커 생성 시점 (Unix time) (ms)</summary>
    [DataMember, JsonProperty("timestamp"), JsonPropertyName("timestamp")]
    public long Timestamp
    {
        get; set;
    }

    /// <summary>고가 (24시간 기준)</summary>
    [DataMember, JsonProperty("high"), JsonPropertyName("high")]
    public string? High
    {
        get; set;
    }

    /// <summary>저가 (24시간 기준)</summary>
    [DataMember, JsonProperty("low"), JsonPropertyName("low")]
    public string? Low
    {
        get; set;
    }

    /// <summary>시가 (24시간 기준)</summary>
    [DataMember, JsonProperty("first"), JsonPropertyName("first")]
    public string? First
    {
        get; set;
    }

    /// <summary>종가 (24시간 기준)</summary>
    [DataMember, JsonProperty("last"), JsonPropertyName("last")]
    public string? Last
    {
        get; set;
    }

    /// <summary>24시간 기준 종목 체결 금액 (원화)</summary>
    [DataMember, JsonProperty("quote_volume"), JsonPropertyName("quote_volume")]
    public string? QuoteVolume
    {
        get; set;
    }

    /// <summary>24시간 기준 종목 체결량 (종목)</summary>
    [DataMember, JsonProperty("target_volume"), JsonPropertyName("target_volume")]
    public string? TargetVolume
    {
        get; set;
    }

    /// <summary>티커 별 ID 값으로 클수록 최신 티커 정보</summary>
    [DataMember, JsonProperty("id"), JsonPropertyName("id")]
    public string? Id
    {
        get; set;
    }

    [DataMember, JsonProperty("yesterday_high"), JsonPropertyName("yesterday_high"), NotMapped]
    public string? YesterdayHigh
    {
        get; set;
    }

    [DataMember, JsonProperty("yesterday_low"), JsonPropertyName("yesterday_low"), NotMapped]
    public string? YesterdayLow
    {
        get; set;
    }

    [DataMember, JsonProperty("yesterday_first"), JsonPropertyName("yesterday_first"), NotMapped]
    public string? YesterdayFirst
    {
        get; set;
    }

    [DataMember, JsonProperty("yesterday_last"), JsonPropertyName("yesterday_last"), NotMapped]
    public string? YesterdayLast
    {
        get; set;
    }

    [DataMember, JsonProperty("yesterday_quote_volume"), JsonPropertyName("yesterday_quote_volume"), NotMapped]
    public string? YesterdayQuoteVolume
    {
        get; set;
    }

    [DataMember, JsonProperty("yesterday_target_volume"), JsonPropertyName("yesterday_target_volume"), NotMapped]
    public string? YesterdayTargetVolume
    {
        get; set;
    }
}