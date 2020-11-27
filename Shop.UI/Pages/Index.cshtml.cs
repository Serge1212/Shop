using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.ProductsAdmin;
using Shop.Database;


namespace Shop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }
        
        public void OnGet()
        {
            Products = new GetProducts(_context).Do();
        }
    }
}
