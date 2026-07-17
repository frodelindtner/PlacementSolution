using Microsoft.AspNetCore.Mvc;
using PlacementTableApp.Services.Interfaces;

namespace PlacementTableApp.Controllers
{
    public class StandingController: Controller
    {
        private readonly ITeamService _teamService;

        public StandingController(ITeamService teamService) 
        { 
            _teamService = teamService;
        }

        public IActionResult Index()
        {


            return View();
        }

        [Route("/Standing/League/{league}")]
        public IActionResult League(string league)
        {

            ViewData["FilterOptionLeague"] ??= _teamService.CreateFilers();


            return View();
        }
    }
}
