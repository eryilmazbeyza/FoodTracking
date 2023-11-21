using foodtrackingcodefirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace foodtrackingcodefirst.Controllers
{
    public class NutritionController : Controller
    {
        public readonly ApplicationDbContext dbContext;
        public NutritionController(ApplicationDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public IActionResult Index(string x)
        {
            var result = from a in dbContext.nutritions
                         select a;

            if (x != null)
            {
                result = result.Where(i => i.NutritionType.Contains(x));
            }
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Nutrition nutrition)
        {
            dbContext.Add(nutrition);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var update = dbContext.nutritions.Find(id);
            return View(update);
        }

        [HttpPost]
        public IActionResult Edit(int id, Nutrition nutrition)
        {
            dbContext.Update(nutrition);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var delete = dbContext.nutritions.Find(id);
            return View(delete);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Sil(int id)
        {
            var delete = dbContext.nutritions.Find(id);
            dbContext.nutritions.Remove(delete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
