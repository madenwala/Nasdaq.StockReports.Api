namespace Nasdaq.StockReports.Api.Models
{
    public sealed class EarningsMomentumResponse: DataResponse<EarningsMomemtum>
    {
    }

    public sealed class EarningsMomemtum
    {
        public string symbol { get; set; }
        public Changeinconsensus changeInConsensus { get; set; }
        public Estimateschanged estimatesChanged { get; set; }
        public string textInfo { get; set; }
    }

    public class Changeinconsensus
    {
        public Monthdata monthData { get; set; }
        public Weekdata weekData { get; set; }
        public Currentdata currentData { get; set; }
        public string fiscalYearEndText { get; set; }
        public string fiscalQtrEndText { get; set; }
    }

    public class Monthdata
    {
        public string period { get; set; }
        public float qtrMean { get; set; }
        public float yrMean { get; set; }
    }

    public class Weekdata
    {
        public string period { get; set; }
        public float qtrMean { get; set; }
        public float yrMean { get; set; }
    }

    public class Currentdata
    {
        public string period { get; set; }
        public float qtrMean { get; set; }
        public float yrMean { get; set; }
    }

    public class Estimateschanged
    {
        public Quarterdatadown quarterDataDown { get; set; }
        public Quarterdataup quarterDataUp { get; set; }
        public Yeardatadown yearDataDown { get; set; }
        public Yeardataup yearDataUp { get; set; }
        public string qtrFiscalQtrEndText { get; set; }
        public string yrFiscalYearEndText { get; set; }
    }

    public class Quarterdatadown
    {
        public string changeType { get; set; }
        public int changeValue { get; set; }
    }

    public class Quarterdataup
    {
        public string changeType { get; set; }
        public int changeValue { get; set; }
    }

    public class Yeardatadown
    {
        public string changeType { get; set; }
        public int changeValue { get; set; }
    }

    public class Yeardataup
    {
        public string changeType { get; set; }
        public int changeValue { get; set; }
    }
}