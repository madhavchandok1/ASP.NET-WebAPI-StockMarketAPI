using api.Dtos.Stock;
using api.Models;

namespace api.Mapper
{
    public static class StockMapper
    {
        public static StockDto toStockDto(this Stock stock)
        {
            return new StockDto
            {
                ID = stock.ID,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap,
                Comments = stock.Comments.Select(c => c.toWACommentDTO()).ToList()
            };
        }

        public static Stock toStockFromCreateStockDto(this CreateStockRequestDto createStockRequestDto)
        {
            return new Stock
            {
                Symbol = createStockRequestDto.Symbol,
                CompanyName = createStockRequestDto.CompanyName,
                Purchase = createStockRequestDto.Purchase,
                LastDiv = createStockRequestDto.LastDiv,
                Industry = createStockRequestDto.Industry,
                MarketCap = createStockRequestDto.MarketCap
            };
        }
    }
}
