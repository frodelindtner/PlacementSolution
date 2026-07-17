using Microsoft.AspNetCore.Mvc;
using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Services.Interfaces;

namespace PlacementTableApp.Controllers
{
    public class StandingController: Controller
    {
        private readonly ITeamService _teamService;
        private readonly IStandingService _standingUSService;
        private List<StandingView> _standingViewLocal;

        public StandingController(ITeamService teamService, IStandingService standingUSService) 
        { 
            _teamService = teamService;
            _standingUSService = standingUSService;

            
            _standingViewLocal = _standingUSService.GetStandingLocalAsync().Result;
        }

        public IActionResult Index()
        {
            var list = _standingViewLocal.ToList();
            return View(list);
        }

        [Route("/Standing/League/{league}")]
        public IActionResult League(string league)
        {

            ViewData["FilterOptionLeague"] ??= _teamService.CreateFilers();
            var list = _standingViewLocal.ToList();

            var fList = list.Where(x => x.League == league).ToList();

            return View(fList);
        }
    }
}
