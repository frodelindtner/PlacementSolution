using Microsoft.AspNetCore.Mvc;

namespace PlacementTableApp.Controllers
{
    public class StandingController: Controller
    {
        public StandingController() { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
