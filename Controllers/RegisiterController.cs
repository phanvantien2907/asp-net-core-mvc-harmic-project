using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Utilities;

namespace WebApplication1.Controllers
{
    public class RegisiterController : Controller
    {

        private readonly HarmicContext _context;

        public RegisiterController(HarmicContext context)
        {
            _context = context;
        }

        [Route("dang-ky")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        
        public IActionResult Index(TbAccount user)
        {
            
            return View(); // làm thành công đổi thành login
        }
    }
}
