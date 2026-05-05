using Microsoft.AspNetCore.Mvc;
using phoneshop.Models;

namespace phoneshop.Controllers
{
    public class AdminController : Controller
    {
        private static phoneshop.Models.Admin adminUser = new phoneshop.Models.Admin
        {
            Username = "admin",
            Password = "admin123"
        };

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(phoneshop.Models.Admin admin)
        {
            if (admin.Username == adminUser.Username && admin.Password == adminUser.Password)
            {
                HttpContext.Session.SetString("AdminUser", admin.Username);
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        public IActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AdminUser")))
                return RedirectToAction("Login");

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }
    }
}
