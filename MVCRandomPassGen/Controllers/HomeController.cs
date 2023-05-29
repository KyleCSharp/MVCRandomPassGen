using Microsoft.AspNetCore.Mvc;
using System;
using MVCRandomPassGen.Models;
using System.Text;

namespace MVCRandomPassGen.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GeneratePassword(int length, bool includeSpecial)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            if (includeSpecial)
            {
                chars += "!@#$%^&*()";
            }

            Random random = new Random();
            StringBuilder password = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(chars.Length);
                password.Append(chars[randomIndex]);
            }

            ViewBag.Password = password.ToString();

            return View("Index");
        }


    }
}
