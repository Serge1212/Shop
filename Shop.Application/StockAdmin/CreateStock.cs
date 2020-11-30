using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
    public class CreateStock
    {
        private ApplicationDbContext _context;

        public CreateStock(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Responce> Do(Request request)
        {
            var stock = new Stock
            {
                Description = request.Description,
                Qty = request.Qty,
                ProductId = request.ProductId
            };

            _context.Add(stock);

            await _context.SaveChangesAsync();
            return new Responce
            {
                Id = stock.Id,
                Description = stock.Description,
                Qty = stock.Qty
            };
        }


        public class Request
        {
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }         
        }  
        
        public class Responce
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
        }
    }
}
