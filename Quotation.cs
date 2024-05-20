using Newtonsoft.Json;

using RestSharp;

using ShareInvest.Coinone.Models;
using ShareInvest.Crypto;

using System.Net;

namespace ShareInvest.Coinone;

public class Quotation : ShareQuotation
{
    public Quotation() : base("https://api.coinone.co.kr/public/v2")
    {

    }

    public async Task<CoinoneMarket?> GetMarketAsync(string? quoteCurrency = null)
    {
        var krw = string.IsNullOrEmpty(quoteCurrency);

        RestResponse response;

        if (krw)
        {
            response = await GetMarketAsync(krw);
        }
        else
        {
            response = await ExecuteAsync(new RestRequest($"currencies/{quoteCurrency}"), cts.Token);
        }

        if (HttpStatusCode.OK == response.StatusCode && !string.IsNullOrEmpty(response.Content))
        {
            return JsonConvert.DeserializeObject<CoinoneMarket>(response.Content);
        }
        return null;
    }

    public override async Task<RestResponse> GetMarketAsync(bool krw)
    {
        return await ExecuteAsync(new RestRequest("currencies"), cts.Token);
    }

    /// <summary>
    /// 전체 티커: ticker_new/{quote_currency}, ticker_utc_new/{quote_currency}
    /// 개별 티커: ticker_new/{quote_currency}/{target_currency}, ticker_utc_new/{quote_currency}/{target_currency}
    /// </summary>
    public async Task<CoinoneTicker?> GetTickerAsync(bool utc, string? targetCurrency = null, bool yesterday = false)
    {
        string path1 = utc ? "ticker_utc_new" : "ticker_new", path2 = "KRW", path3 = $"?additional_data={yesterday}";

        RestResponse res;

        if (string.IsNullOrEmpty(targetCurrency))
        {
            res = await GetTickerAsync(path1, path2, path3);
        }
        else
        {
            res = await GetTickerAsync(path1, path2, targetCurrency, path3);
        }

        if (HttpStatusCode.OK == res.StatusCode && !string.IsNullOrEmpty(res.Content))
        {
            return JsonConvert.DeserializeObject<CoinoneTicker>(res.Content);
        }
        return null;
    }

    public override async Task<RestResponse> GetTickerAsync(params string[] args)
    {
        string resource;

        if (args.Length == 3)
        {
            resource = Path.Combine(args[0], args[1], args[2]);
        }
        else
        {
            resource = Path.Combine(args[0], args[1], args[2], args[^1]);
        }
        return await ExecuteAsync(new RestRequest(resource), cts.Token);
    }

    readonly CancellationTokenSource cts = new();
}