namespace api.Dtos.Stock
{
    public class NDStockDTO
    {
        public int ID { get; set; }

        public string Symbol { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; }
    }
}
