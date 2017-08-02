using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCMonteCarloPI.ViewModels;

namespace MVCMonteCarloPI.Controllers
{
    [Route("/")]
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MainViewModel model)
        {
            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("/github")]
        public IActionResult GitHub()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

    }
}
