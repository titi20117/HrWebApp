﻿using Microsoft.AspNetCore.Mvc;

namespace HrWebApp.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
