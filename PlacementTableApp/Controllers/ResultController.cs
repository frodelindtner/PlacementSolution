using Microsoft.AspNetCore.Mvc;

namespace PlacementTableApp.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
