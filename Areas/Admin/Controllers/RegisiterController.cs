using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/dang-ky-tai-khoan")]
    public class RegisiterController : Controller
    {

        private readonly HarmicContext _context;

        public RegisiterController(HarmicContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(TbAdminUser model)
        {
            if (ModelState.IsValid)
            {
                TbAdminUser user = new TbAdminUser
                {
                    UserName = model.UserName,
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = model.Password,
                    IsActive = true
                };

                try
                {
                    _context.TbAdminUsers.Add(user);
                    await _context.SaveChangesAsync();

                    ModelState.Clear();
                    TempData["Sucesss"] = $"Tài khoản {model.Email} được tạo tài khoản thành công! Vui lòng đăng nhập";

                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Errors"] = "Đã xảy ra lỗi khi tạo tài khoản, vui lòng thử lại hoặc liên hệ admin!";
                    return View(model);
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }



    }
}
