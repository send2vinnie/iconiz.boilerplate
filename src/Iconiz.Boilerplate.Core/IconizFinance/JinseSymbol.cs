namespace Iconiz.Boilerplate.IconizFinance
{
    public class JinseSymbol
    {
        public string name { get; set; }
        public string name_cn { get; set; }
        public string name_en { get; set; }
        public string ticker { get; set; }
        public int currencyId { get; set; }
        public string currency { get; set; }
        public string exchangeTraded { get; set; }
        public string exchangeListed { get; set; }
        public string timezone { get; set; }
        public int minmov { get; set; }
        public int pricescale { get; set; }
    }
    
    public class JinseTicker
    {
        public string ticker { get; set; }
        public string exchangeName { get; set; }
        public string @base { get; set; }
        public string currency { get; set; }
        public string symbol { get; set; }
        public float high { get; set; }
        public float open { get; set; }
        public float close { get; set; }
        public float low { get; set; }
        public float vol { get; set; }
        public float degree { get; set; }
        public long dateTime { get; set; }
    }
}