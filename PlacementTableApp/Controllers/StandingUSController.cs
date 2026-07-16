using Microsoft.AspNetCore.Mvc;
using PlacementTableApp.Models.DTOs;

namespace PlacementTableApp.Controllers
{
    public class StandingUSController : Controller
    {
        public StandingUSController() { }
        public IActionResult Index()
        {
            var data = new List<Standing>
            {
                new("2024", "Regular", 1, "New York", "Yankees", "AL", "East", 95, 67, 50),
                new("2024", "Regular", 2, "Los Angeles", "Dodgers", "NL", "West", 92, 70, 48),
                new("2024", "Regular", 3, "Chicago", "Cubs", "NL", "Central", 88, 74, 45),
            };
            return View(data);
        }
    }
}
