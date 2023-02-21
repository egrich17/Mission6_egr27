using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieFormContext movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieFormContext X)
        {
            _logger = logger;
            movieContext = X;
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
            ViewBag.Categories = movieContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(FormResponse fr)
        {
            // if model is valid, add to list, save changes, and confirm the form
            // submission to the user
            if (ModelState.IsValid)
            {
                movieContext.Add(fr);
                movieContext.SaveChanges();

                return View("Confirmation", fr);
            }

            else // if invalid, make user fix errors
            {
                ViewBag.Categories = movieContext.Categories.ToList();

                return View();
            }
        }

        public IActionResult MovieList()
        {
            var forms = movieContext.responses.Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ToList();
            return View(forms);
        }
        
        [HttpGet]
        public IActionResult Edit(int formid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var form = movieContext.responses.Single(x => x.FormId == formid);

            return View("MovieForm", form);
        }

        [HttpPost]
        public IActionResult Edit (FormResponse fr)
        {
            movieContext.Update(fr);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int formid)
        {
            var form = movieContext.responses.Single(x => x.FormId == formid);
            return View(form);
        }

        [HttpPost]
        public IActionResult Delete(FormResponse fr)
        {
            movieContext.responses.Remove(fr);
            movieContext.SaveChanges();
            return RedirectToAction("MovieList");
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
