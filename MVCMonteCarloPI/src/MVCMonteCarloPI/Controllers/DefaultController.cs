using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCMonteCarloPI.Entities;

namespace MVCMonteCarloPI.Controllers
{
    [Route("/")]
    public class DefaultController : Controller
    {
     
        [HttpGet]
        public IActionResult IndexGET(Properties model)
        {
            if (model.SquareSide != 0)
                return View("Index", model);

            return View("Index");
        }

        [HttpPost]
        public IActionResult IndexPOST(Properties model)
        {
            model.CalculatedPI = Logic.CalculatePI(model.PointsAmount, model.SquareSide);

            return RedirectToAction("IndexGET", model);
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
