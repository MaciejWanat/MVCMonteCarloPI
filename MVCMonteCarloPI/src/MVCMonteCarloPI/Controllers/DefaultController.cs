using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCMonteCarloPI.ViewModels;
using MVCMonteCarloPI.Entities;

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
        public IActionResult Index(Properties model)
        {
            model.CalculatedPI = Logic.CalculatePI(model.PointsAmount, model.SquareSide);

            return RedirectToAction("IndexDisplay", model);
        }

        [Route("display")]
        [HttpGet]
        public IActionResult IndexDisplay(Properties model)
        {
            return View("Index", model);
        }

        [Route("about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("github")]
        public IActionResult GitHub()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

    }
}
