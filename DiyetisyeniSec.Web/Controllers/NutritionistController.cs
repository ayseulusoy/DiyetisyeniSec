using DiyetisyeniSec.Data;
using DiyetisyeniSec.Domain.Nutritionist;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DiyetisyeniSec.Web.Controllers
{
    public class NutritionistController : Controller
    {
        private readonly DiyetisyenDbContext _context;
        public NutritionistController(DiyetisyenDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            var diyetisyenler=_context.Nutritionists.ToList();
            return View(diyetisyenler);
        }

        //GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //Güvenlik için gerekli istek sahteciliğini önler
        public IActionResult Create(Nutritionist nutritionist)
        {
            if(nutritionist.Experience<4 && nutritionist.Experience>2 && nutritionist.UniversityName != "Akdeniz Universitesi")
            {
                ModelState.AddModelError("experience", "Eğer Akdeniz Üniversitesi Mezunu Değilseniz En Az 4 Yıl Tecübeniz Olmak Zorunda."); 
                //küçük modal ismini yazıp yaprsak altta olur hata mesajı
            }

            if (ModelState.IsValid)
            {
                _context.Nutritionists.Add(nutritionist);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nutritionist);
        }
    }
}
