using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Coinone.Models;

public class Market
{
    /// <summary>종목의 영문명</summary>
    [DataMember, JsonProperty("name"), JsonPropertyName("name")]
    public string? Name
    {
        get; set;
    }

    /// <summary>종목의 심볼</summary>
    [DataMember, JsonProperty("symbol"), JsonPropertyName("symbol")]
    public string? Code
    {
        get; set;
    }

    /// <summary>입금 가능 여부 상태(DepositStatus)</summary>
    [DataMember, JsonProperty("deposit_status"), JsonPropertyName("deposit_status")]
    public DepositStatus DepositStatus
    {
        get; set;
    }

    /// <summary>출금 가능 여부 상태(enum)</summary>
    [DataMember, JsonProperty("withdraw_status"), JsonPropertyName("withdraw_status")]
    public WithdrawStatus WithdrawStatus
    {
        get; set;
    }

    /// <summary>입금 컨펌 수</summary>
    [DataMember, JsonProperty("deposit_confirm_count"), JsonPropertyName("deposit_confirm_count")]
    public int DepositConfirmCount
    {
        get; set;
    }

    /// <summary>
    /// 출금 가능한 소숫점 아래 자릿수
    /// ex) 0.12345678 까지가능하면
    /// max_precision = 8
    /// </summary>
    [DataMember, JsonProperty("max_precision"), JsonPropertyName("max_precision")]
    public int MaxPrecision
    {
        get; set;
    }

    /// <summary>입금 수수료</summary>
    [DataMember, JsonProperty("deposit_fee"), JsonPropertyName("deposit_fee")]
    public string? DepositFee
    {
        get; set;
    }

    /// <summary>최소 출금 가능 수량</summary>
    [DataMember, JsonProperty("withdrawal_min_amount"), JsonPropertyName("withdrawal_min_amount")]
    public string? WithdrawalMinAmount
    {
        get; set;
    }

    /// <summary>출금 수수료</summary>
    [DataMember, JsonProperty("withdrawal_fee"), JsonPropertyName("withdrawal_fee")]
    public string? WithdrawalFee
    {
        get; set;
    }
}