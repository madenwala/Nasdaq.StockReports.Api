using System;
using System.Globalization;
using System.Text.RegularExpressions;

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

        public DateTime? EstimatedDate
        {
            get
            {
                if (!string.IsNullOrEmpty(this.reportText))
                {
                    var regex = new Regex(@"\d{2}\/\d{2}\/\d{4}");
                    foreach (Match m in regex.Matches(this.reportText))
                    {
                        DateTime dt;
                        if (DateTime.TryParseExact(m.Value, "MM/dd/yyyy", null, DateTimeStyles.None, out dt))
                            return dt;
                    }
                }

                return null;
            }
        }

        public bool IsEstimated
        {
            get
            {
                return this.reportText?.IndexOf("estimated", StringComparison.InvariantCultureIgnoreCase) >= 0;
            }
        }

        public bool IsBeforeMarketOpen
        {
            get
            {
                return this.reportText?.IndexOf("before market open", StringComparison.InvariantCultureIgnoreCase) >= 0;
            }
        }
    }
}