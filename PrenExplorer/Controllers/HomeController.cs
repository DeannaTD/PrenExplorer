using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrenExplorer.Data;
using PrenExplorer.Models;

namespace PrenExplorer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NewGenContext _context;

        public HomeController(ILogger<HomeController> logger, NewGenContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //return View("Error");
            if (User.IsInRole("dev")) return View();
            if (User.IsInRole("Manager")) return RedirectToAction("Index", "Manager");
            if (User.IsInRole("Mentor")) return RedirectToAction("Index", "Mentor");
            if (User.IsInRole("Student")) return RedirectToAction("Index", "Student");
            else return View();
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

        public async Task CreateHelpers()
        {
            _context.Status.Add(new Status()
            {
                Name = "Interested"
            });
            _context.Status.Add(new Status()
            {
                Name = "Trial"
            });
            _context.Status.Add(new Status()
            {
                Name = "Active"
            });

            _context.Status.Add(new Status()
            {
                Name = "Staff"
            });
            _context.Status.Add(new Status()
            {
                Name = "Blocked"
            });
            _context.Status.Add(new Status()
            {
                Name = "Archived"
            });
            await _context.SaveChangesAsync();
        }

    }
}
