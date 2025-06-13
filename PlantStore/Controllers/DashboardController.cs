using Microsoft.AspNetCore.Mvc;

namespace PlantStore.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
