using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace Harmic.Controllers
{
    public class BlogController : Controller
    {
        private readonly HarmicContext _context;

        public BlogController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("/blog/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbBlogs == null)
            {
                return NotFound();
            }

            var blogs = await _context.TbBlogs.FirstOrDefaultAsync(m => m.BlogId == id);

            if (blogs == null)
            {
                return NotFound();
            }

            ViewBag.blogComment = _context.TbBlogComments.Where(m => m.BlogId == id && m.IsActive == true).ToList();

            return View(blogs);
        }

        [HttpPost]
        public async Task<IActionResult> AddnewComment(TbBlogComment model)
        {
            try
            {
                var newcmt = new TbBlogComment
                {
                    BlogId = model.BlogId,
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    CreatedDate = DateTime.Now,
                    Detail = model.Detail,
                    IsActive = true
                };
                await _context.TbBlogComments.AddAsync(newcmt);
                await _context.SaveChangesAsync();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }

        }
    }
}
