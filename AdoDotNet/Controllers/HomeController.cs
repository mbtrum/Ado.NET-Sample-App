using AdoDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdoDotNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
