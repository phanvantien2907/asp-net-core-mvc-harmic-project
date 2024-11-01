using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenusController : Controller
    {
        private readonly HarmicContext _context;

        public MenusController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var menus = _context.TbMenus.ToList();
            return View(menus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,Title,Alias,Description,Levels,ParentId,Position,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive")] TbMenu tbMenu)
        {
            if (ModelState.IsValid)
            {
                tbMenu.Alias = WebApplication1.Utilities.Function.TittleGenerationAlias(tbMenu.Title); 
                _context.Add(tbMenu); 
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbMenu); 
        }

        public IActionResult Create()
        {
            return View();
        }

        // GET THÔNG TIN
        public  IActionResult Edit()
        {
           
            return View();
        }

        public ActionResult Delete() 
        {
            
            return View();
        }

        
        public ActionResult Details()
        {
            
            return View();
        }

        
    }
}
