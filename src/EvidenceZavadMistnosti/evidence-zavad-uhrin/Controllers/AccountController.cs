using evidence_zavad_uhrin.Data;
using evidence_zavad_uhrin.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;

namespace evidence_zavad_uhrin.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string confirmPassword)
        {
            // 1️⃣ kontrola hesel
            if (password != confirmPassword)
            {
                ModelState.AddModelError("", "Hesla se neshodují.");
                return View();
            }

            // 2️⃣ kontrola existujícího uživatele
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Username == username);

            if (existingUser != null)
            {
                ModelState.AddModelError("", "Uživatel již existuje.");
                return View();
            }

            // 4️⃣ vytvoření uživatele
            var user = new User
            {
                Username = username,
                Password = password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            // 5️⃣ přesměrování na Login
            return RedirectToAction("Login");
        }
    }
}
