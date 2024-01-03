using Microsoft.AspNetCore.Mvc;

namespace DatabaseProject.Controllers
{
    public class ScanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
