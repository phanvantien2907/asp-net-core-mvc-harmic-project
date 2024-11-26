using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class FileManagerController : Controller
    {
        [Area("Admin")]
        [Route("/Admin/file-manager")]
        [Authorize(AuthenticationSchemes = "AdminScheme")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
