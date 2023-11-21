using Microsoft.AspNetCore.Mvc;

namespace foodtrackingcodefirst.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
