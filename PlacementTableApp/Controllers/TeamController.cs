using Microsoft.AspNetCore.Mvc;

namespace PlacementTableApp.Controllers
{
    public class TeamController: Controller
    {
        public TeamController() { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
