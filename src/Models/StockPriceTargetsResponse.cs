namespace Nasdaq.StockReports.Api.Models
{
    public sealed class StockPriceTargetsResponse : DataResponse<StockPriceTargets>
    {
    }

    public class StockPriceTargets
    {
        public string symbol { get; set; }
        public Consensusoverview consensusOverview { get; set; }
        public Historicalconsensu[] historicalConsensus { get; set; }
    }

    public class Consensusoverview
    {
        public float lowPriceTarget { get; set; }
        public float highPriceTarget { get; set; }
        public float priceTarget { get; set; }
        public int buy { get; set; }
        public int sell { get; set; }
        public int hold { get; set; }
    }

    public class Historicalconsensu
    {
        public Z z { get; set; }
        public int x { get; set; }
        public float y { get; set; }
    }

    public class Z
    {
        public int buy { get; set; }
        public int hold { get; set; }
        public int sell { get; set; }
        public string date { get; set; }
        public string consensus { get; set; }
        public Latest latest { get; set; }
    }

    public class Latest
    {
        public float high { get; set; }
        public float avg { get; set; }
        public float low { get; set; }
    }
}