using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly HarmicContext _context;

        public MenuTopViewComponent(HarmicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMenus
                .Where(m => m.IsActive.HasValue && m.IsActive.Value)
                .OrderBy(m => m.Position)
                .ToList();

            return await Task.FromResult(View(items));
        }
    }
}
