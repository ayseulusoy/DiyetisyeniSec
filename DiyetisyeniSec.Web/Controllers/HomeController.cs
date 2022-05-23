using DiyetisyeniSec.Data;
using DiyetisyeniSec.Domain.Nutritionist;
using DiyetisyeniSec.Domain.SharedConstants;
using DiyetisyeniSec.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DiyetisyeniSec.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DiyetisyenDbContext _context; //startup
        public HomeController(ILogger<HomeController> logger,DiyetisyenDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //veri tabanına yeni kayıt ekledik
            /*
            Nutritionist newNutritionist = new Nutritionist
            {
                Name = "Haydar Tuzun",
                CompanyName = "Tuzun Estetik",
                UniversityName = "Akdeniz Universitesi",
                City = "Antalya",
                Gender = Genders.Male,
            };
            newNutritionist.SetExperience(3);

            _context.Nutritionists.Add(newNutritionist);
            _context.SaveChanges();
            */
            return View();
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
