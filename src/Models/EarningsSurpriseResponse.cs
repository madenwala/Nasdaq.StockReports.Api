namespace Nasdaq.StockReports.Api.Models
{
    public sealed class EarningsSurpriseResponse : DataResponse<EarningsSurprise>
    {
    }

    public class EarningsSurprise
    {
        public string symbol { get; set; }
        public Chart[] chart { get; set; }
        public Earningssurprisetable earningsSurpriseTable { get; set; }
    }

    public class Earningssurprisetable
    {
        public EsHeaders headers { get; set; }
        public EsRow[] rows { get; set; }
    }

    public class EsHeaders
    {
        public string fiscalQtrEnd { get; set; }
        public string dateReported { get; set; }
        public string eps { get; set; }
        public string consensusForecast { get; set; }
        public string percentageSurprise { get; set; }
    }

    public class EsRow
    {
        public string fiscalQtrEnd { get; set; }
        public string dateReported { get; set; }
        public float eps { get; set; }
        public string consensusForecast { get; set; }
        public string percentageSurprise { get; set; }
    }

    public class Chart
    {
        public string x { get; set; }
        public string y { get; set; }
    }
}