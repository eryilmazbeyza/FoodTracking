using foodtrackingcodefirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace foodtrackingcodefirst.Controllers
{
    public class DietController : Controller
    {

            public readonly ApplicationDbContext dbContext;
            public DietController(ApplicationDbContext dbcontext)
            {
                this.dbContext = dbcontext;
            }
            public IActionResult Index(string x)
            {
            var result = from a in dbContext.diets
                         select a;
            if (x != null)
            {
                result = result.Where(i => i.DietType.Contains(x));
            }
            return View(result);
            }

            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Diet diet)
            {
                dbContext.Add(diet);
                dbContext.SaveChanges();
                return RedirectToAction("Index");

            }
            public IActionResult Edit(int id)
            {
                var update = dbContext.diets.Find(id);
                return View(update);
            }

            [HttpPost]
            public IActionResult Edit(int id, Diet diet)
            {
                dbContext.Update(diet);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            public IActionResult Delete(int id)
            {
                var delete = dbContext.diets.Find(id);
                return View(delete);
            }
            [HttpPost, ActionName("Delete")]
            public IActionResult Sil(int id)
            {
                var delete = dbContext.diets.Find(id);
                dbContext.diets.Remove(delete);
                dbContext.SaveChanges();
                return RedirectToAction("Index");

            }
        }
}
