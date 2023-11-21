using Microsoft.AspNetCore.Mvc;

namespace foodtrackingcodefirst.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
