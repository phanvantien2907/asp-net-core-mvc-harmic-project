﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        private readonly HarmicContext _context;

        public ContactController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index()    
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(string name, string phone, string email, string message)
        {
            try
            {
                TbContact contact = new TbContact();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.Message = message;
               await _context.AddAsync(contact);
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
