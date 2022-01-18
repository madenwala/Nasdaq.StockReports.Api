namespace Nasdaq.StockReports.Api.Models
{
    public sealed class StockRatingsResponse : DataResponse<StockRatings>
    {
    }

    public class StockRatings
    {
        public string symbol { get; set; }
        public string meanRatingType { get; set; }
        public string ratingsSummary { get; set; }
        public object[] upgradesDowngrades { get; set; }
        public string[] brokerNames { get; set; }
    }
}