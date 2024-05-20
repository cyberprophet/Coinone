using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Coinone.Models;

public class BestOrderBook
{
    /// <summary>호가</summary>
    [DataMember, JsonProperty("price"), JsonPropertyName("price")]
    public string? Price
    {
        get; set;
    }

    /// <summary>수량</summary>
    [DataMember, JsonProperty("qty"), JsonPropertyName("qty")]
    public string? Quantity
    {
        get; set;
    }
}