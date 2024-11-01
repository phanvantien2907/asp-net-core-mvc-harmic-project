using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly HarmicContext _context;

        public ProductController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/product/{alias}-{id}.html")]
        public async Task <IActionResult> Details(int? id) 
        {
            if (id == null || _context.TbProducts == null )
            {
                return NotFound();
            }

            var products = await _context.TbProducts.Include(i=> i.CategoryProduct).FirstOrDefaultAsync(m => m.ProductId == id);

            if (products == null) 

            { return NotFound(); }

            ViewBag.productReview = _context.TbProductReviews.Where(m => m.ProductId == id && m.IsActive == true).ToList();
            ViewBag.productRelated = _context.TbProducts.Where(i => i.ProductId!= id && i.CategoryProductId == products.CategoryProductId).Take(5).OrderByDescending(i => i.ProductId).ToList();
            return View(products);
        }
    }
}
