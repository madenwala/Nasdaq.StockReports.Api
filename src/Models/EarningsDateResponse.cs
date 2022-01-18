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

        public DateTime? ReportDate
        {
            get
            {
                return Extensions.ParseDate(this.reportText);
            }
        }

        public string CompanyName
        {
            get
            {
                var index = this.reportText.IndexOf(" is");
                if (index > 0 && this.reportText?.Length > index)
                    return this.reportText.Substring(0, index).Trim();
                else
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

        public bool IsNotEstimated
        {
            get
            {
                return this.reportText?.IndexOf("hasn't provided us", StringComparison.InvariantCultureIgnoreCase) >= 0;
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