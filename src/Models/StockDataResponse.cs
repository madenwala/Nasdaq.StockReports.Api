using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Nasdaq.StockReports.Api.Models
{
    public sealed class StockDataResponse : DataResponse<StockData>
    {
        public DateTime? ExDivDate
        {
            get
            {
                return Extensions.ParseDate(this.data?.summaryData?.ExDividendDate?.value);
            }
        }
    }

    public class StockData
    {
        public string symbol { get; set; }
        public Summarydata summaryData { get; set; }
        public string assetClass { get; set; }
        public object additionalData { get; set; }
    }

    public class Summarydata
    {
        public Exchange Exchange { get; set; }
        public Sector Sector { get; set; }
        public Industry Industry { get; set; }
        public Oneyrtarget OneYrTarget { get; set; }
        public Todayhighlow TodayHighLow { get; set; }
        public Sharevolume ShareVolume { get; set; }
        public Averagevolume AverageVolume { get; set; }
        public Previousclose PreviousClose { get; set; }
        public Fifttwoweekhighlow FiftTwoWeekHighLow { get; set; }
        public Marketcap MarketCap { get; set; }
        public Peratio PERatio { get; set; }
        public Forwardpe1yr ForwardPE1Yr { get; set; }
        public Earningspershare EarningsPerShare { get; set; }
        public Annualizeddividend AnnualizedDividend { get; set; }
        public Exdividenddate ExDividendDate { get; set; }
        public Dividendpaymentdate DividendPaymentDate { get; set; }
        public Yield Yield { get; set; }
        public Beta Beta { get; set; }


    }

    public class Exchange
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Sector
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Industry
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Oneyrtarget
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Todayhighlow
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Sharevolume
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Averagevolume
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Previousclose
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Fifttwoweekhighlow
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Marketcap
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Peratio
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Forwardpe1yr
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Earningspershare
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Annualizeddividend
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Exdividenddate
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Dividendpaymentdate
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Yield
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Beta
    {
        public string label { get; set; }
        public string value { get; set; }
    }
}