using foodtrackingcodefirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace foodtrackingcodefirst.Controllers
{
    public class ClinicController : Controller
    {

        public readonly ApplicationDbContext dbContext;
        public ClinicController(ApplicationDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public IActionResult Index(string x)
        {
            var result = from a in dbContext.clinics
                         select a;
            if ( x != null)
            {
                result=result.Where(i=>i.ClinicName.Contains(x));
            }
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Clinic clinic)
        {
            dbContext.Add(clinic);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var update = dbContext.clinics.Find(id);
            return View(update);
        }

        [HttpPost]
        public IActionResult Edit(int id, Clinic clinic)
        {
            dbContext.Update(clinic);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var delete = dbContext.clinics.Find(id);
            return View(delete);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Sil(int id)
        {
            var delete = dbContext.clinics.Find(id);
            dbContext.clinics.Remove(delete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
