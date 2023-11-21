using foodtrackingcodefirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace foodtrackingcodefirst.Controllers
{
    public class MealController : Controller
    {

        public readonly ApplicationDbContext dbContext;
        public MealController(ApplicationDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public IActionResult Index(string x)
        {
            var result = from a in dbContext.meals
                         select a;
            if(x!=null)
            {
                result = result.Where(i => i.MealName.Contains(x));
            }

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Meal meal)
        {
            dbContext.Add(meal);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var update = dbContext.meals.Find(id);
            return View(update);
        }

        [HttpPost]
        public IActionResult Edit(int id,Meal meal)
        {
            dbContext.Update(meal);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var delete = dbContext.meals.Find(id);
            return View(delete);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Sil(int id)
        {
            var delete = dbContext.meals.Find(id);
            dbContext.meals.Remove(delete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
