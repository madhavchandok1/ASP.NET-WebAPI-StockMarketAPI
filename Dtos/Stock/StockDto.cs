﻿using api.Dtos.Comments;

namespace api.Dtos.Stock
{
    public class StockDto
    {
        public int ID { get; set; }
        
        public string Symbol { get; set; } = string.Empty;
        
        public string CompanyName { get; set; } = string.Empty;

        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; }

        public List<WACommentDTO>? Comments { get; set; }
    }
}
