using foodtrackingcodefirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace foodtrackingcodefirst.Controllers
{
    public class DiseaseController : Controller
    {
        public readonly ApplicationDbContext dbContext;
        public DiseaseController(ApplicationDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public IActionResult Index(string x)
        {
            var result = from a in dbContext.diseases
                         select a;

            if (x != null)
            {
                result = result.Where(i => i.DiseaseName.Contains(x));
            }
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Disease disease)
        {
            dbContext.Add(disease);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var update = dbContext.diseases.Find(id);
            return View(update);
        }

        [HttpPost]
        public IActionResult Edit(int id, Disease disease)
        {
            dbContext.Update(disease);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var delete = dbContext.diseases.Find(id);
            return View(delete);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Sil(int id)
        {
            var delete = dbContext.diseases.Find(id);
            dbContext.diseases.Remove(delete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
