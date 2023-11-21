using foodtrackingcodefirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace foodtrackingcodefirst.Controllers
{
    public class PatientController : Controller
    {
        public readonly ApplicationDbContext dbContext;
        public PatientController(ApplicationDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public IActionResult Index(string x )
        {
            var result = from a in dbContext.patients
                         select a;

            if (x != null)
            {
                result = result.Where(i => i.PatientName.Contains(x));
            }
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            dbContext.Add(patient);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var update = dbContext.patients.Find(id);
            return View(update);
        }

        [HttpPost]
        public IActionResult Edit(int id, Patient patient)
        {
            dbContext.Update(patient);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var delete = dbContext.patients.Find(id);
            return View(delete);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Sil(int id)
        {
            var delete = dbContext.patients.Find(id);
            dbContext.patients.Remove(delete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
