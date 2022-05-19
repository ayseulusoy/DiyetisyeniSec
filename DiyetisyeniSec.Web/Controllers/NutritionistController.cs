using DiyetisyeniSec.Data;
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
    }
}
