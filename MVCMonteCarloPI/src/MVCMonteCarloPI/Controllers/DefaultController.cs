﻿using System;
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
        public IActionResult IndexGET(PICalculationModel model)
        {
            if (model.SquareSide != 0)
                return View("Index", model);

            return View("Index");
        }

        [HttpPost]
        public IActionResult IndexPOST(PICalculationModel model)
        {
            model.CalculatePI();
            return RedirectToAction("IndexGET", model);
        }

        [Route("about")]
        public IActionResult About()
        {        
            return View();
        }

    }
}
