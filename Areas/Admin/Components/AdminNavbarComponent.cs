using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Areas.Admin.Components
{
    [ViewComponent(Name = "AdminNavbar")]
    public class AdminNavbarComponent : ViewComponent
    {
        private readonly HarmicContext _context;

        public AdminNavbarComponent(HarmicContext db)
        {
            _context = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var username = User.Identity?.Name;
            var adminnavbar = await _context.TbAdminUsers.Where(mn => mn.IsActive == true).FirstOrDefaultAsync(a => a.Email == username);
            return await Task.FromResult((IViewComponentResult)View("Default", adminnavbar));
        }

    }
}
