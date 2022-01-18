using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Nasdaq.StockReports.Api.Models
{
    public static class Extensions
    {
        public static DateTime? ParseDate(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                DateTime dt;
                if (DateTime.TryParse(message, out dt))
                    return dt;

                var regex = new Regex(@"\d{2}\/\d{2}\/\d{4}");
                foreach (Match m in regex.Matches(message))
                {
                    DateTime dtLoop;
                    if (DateTime.TryParseExact(m.Value, "MM/dd/yyyy", null, DateTimeStyles.None, out dtLoop))
                        return dtLoop;
                }
            }

            return null;
        }
    }

    public class DataResponse<T>
    {
        public T data { get; set; }
        public object message { get; set; }
        public Status status { get; set; }
    }

    public class Status
    {
        public int rCode { get; set; }
        public object bCodeMessage { get; set; }
        public object developerMessage { get; set; }
    }
}