using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {

        private readonly HarmicContext _context;

        public BlogViewComponent(HarmicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbBlogs
                .Where(m => m.IsActive.HasValue && m.IsActive.Value)
                .OrderBy(m => m.Description)
                .ToList();

            return await Task.FromResult(View(items));
        }
    }
}
