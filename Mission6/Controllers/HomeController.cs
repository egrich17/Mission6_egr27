using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // get info from context file to controller
        private MovieFormContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieFormContext X)
        {
            _logger = logger;
            _movieContext = X;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts ()
        {
            return View("MyPodcasts");
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View("MovieForm");
        }

        [HttpPost]
        public IActionResult MovieForm(FormResponse fr)
        {
            _movieContext.Add(fr);
            _movieContext.SaveChanges();

            return View("Confirmation", fr);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
