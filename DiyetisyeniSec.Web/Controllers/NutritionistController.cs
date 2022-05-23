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

        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var diyetisyen= _context.Nutritionists.FirstOrDefault(x => x.Id == id);
            if (diyetisyen==null)
            {
                return NotFound();
            }
            return View(diyetisyen);
            /*
           _context.Nutritionists.Find(id);
           _context.Nutritionists.FirstOrDefault(x => x.Id == id);
           _context.Nutritionists.SingleOrDefault(x => x.Id == id);
           */
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //Güvenlik için gerekli istek sahteciliğini önler
        public IActionResult Edit(Nutritionist nutritionist)
        {
            if (nutritionist.Experience < 4 && nutritionist.Experience > 2 && nutritionist.UniversityName != "Akdeniz Universitesi")
            {
                ModelState.AddModelError("experience", "Eğer Akdeniz Üniversitesi Mezunu Değilseniz En Az 4 Yıl Tecübeniz Olmak Zorunda.");
                //küçük modal ismini yazıp yaprsak altta olur hata mesajı
            }

            if (ModelState.IsValid)
            {
                _context.Nutritionists.Update(nutritionist);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nutritionist);
        }

        public IActionResult Delete(int? id)
        {
            var diyetisyen= _context.Nutritionists.FirstOrDefault(x => x.Id==id);
            if (diyetisyen==null)
            {
                return NotFound();
            }
            
            return View(diyetisyen);
        }
        [HttpPost,ActionName("Delete")] //ActionName bir attribute tags örneğidir.
        public IActionResult DeletePost(int? id)
        {
            var diyetisyen = _context.Nutritionists.FirstOrDefault(x => x.Id == id);
            if (diyetisyen == null)
            {
                return NotFound();
            }
            _context.Nutritionists.Remove(diyetisyen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
