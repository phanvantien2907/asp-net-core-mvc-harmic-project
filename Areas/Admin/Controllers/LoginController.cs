using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/dang-nhap")]
    public class LoginController : Controller
    {

        private readonly HarmicContext _context;

        public LoginController(HarmicContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index(string? Returnurl)
        {
            ViewBag.Returnurl = Returnurl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(TbAdminUser model, string? Returnurl)
        {
            ViewBag.Returnurl = Returnurl;


            if (ModelState.IsValid)
            {
                var user = await _context.TbAdminUsers.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefaultAsync();


                if (user != null && !string.IsNullOrEmpty(user.Email))
                {
                    //  login success, create cookie
                    var claims = new List<Claim>
                    {

                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(MySetting.CLAIM_CUSTOMERID, user.Email),

                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (Url.IsLocalUrl(Returnurl))
                    {
                        return Redirect(Returnurl);
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }



                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác!");
                    return View(model);
                }
            }
            return View();
        }


        [Authorize(AuthenticationSchemes = "AdminScheme")]
        public async Task<IActionResult> DangXuat(string? Returnurl)
        {
            await HttpContext.SignOutAsync();

            if(!string.IsNullOrEmpty(Returnurl)) 
                {
                return Redirect(Returnurl);
                }

            return RedirectToAction("Index", "Home");
        }

    }
}


