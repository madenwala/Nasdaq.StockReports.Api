namespace Nasdaq.StockReports.Api.Models
{
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