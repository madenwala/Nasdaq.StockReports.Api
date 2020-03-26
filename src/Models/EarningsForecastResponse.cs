namespace Nasdaq.StockReports.Api.Models
{
    public sealed class EarningsForecastResponse : DataResponse<EarningsForecast>
    {
    }

    public sealed class EarningsForecast
    {
        public string symbol { get; set; }
        public Quarterlyforecast quarterlyForecast { get; set; }
        public Yearlyforecast yearlyForecast { get; set; }
    }

    public class Quarterlyforecast
    {
        public QfHeaders headers { get; set; }
        public QfRow[] rows { get; set; }
    }

    public class QfHeaders
    {
        public string fiscalEnd { get; set; }
        public string consensusEPSForecast { get; set; }
        public string highEPSForecast { get; set; }
        public string lowEPSForecast { get; set; }
        public string noOfEstimates { get; set; }
        public string up { get; set; }
        public string down { get; set; }
    }

    public class QfRow
    {
        public string fiscalEnd { get; set; }
        public float consensusEPSForecast { get; set; }
        public float highEPSForecast { get; set; }
        public float lowEPSForecast { get; set; }
        public int noOfEstimates { get; set; }
        public int up { get; set; }
        public int down { get; set; }
    }

    public class Yearlyforecast
    {
        public YfHeaders1 headers { get; set; }
        public YfRow[] rows { get; set; }
    }

    public class YfHeaders1
    {
        public string fiscalEnd { get; set; }
        public string consensusEPSForecast { get; set; }
        public string highEPSForecast { get; set; }
        public string lowEPSForecast { get; set; }
        public string noOfEstimates { get; set; }
        public string up { get; set; }
        public string down { get; set; }
    }

    public class YfRow
    {
        public string fiscalEnd { get; set; }
        public float consensusEPSForecast { get; set; }
        public float highEPSForecast { get; set; }
        public float lowEPSForecast { get; set; }
        public int noOfEstimates { get; set; }
        public int up { get; set; }
        public int down { get; set; }
    }
}