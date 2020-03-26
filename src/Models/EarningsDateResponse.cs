using System;

namespace Nasdaq.StockReports.Api.Models
{
    public sealed class EarningsDateResponse : DataResponse<EarningsDate>
    {
    }

    public sealed class EarningsDate
    {
        public string heading { get; set; }
        public string announcement { get; set; }
        public string reportText { get; set; }

        public DateTime? Date
        {
            get
            {
                return DateTime.Now;
            }
        }

        public bool IsEstimated
        {
            get
            {
                return true;
            }
        }
    }
}