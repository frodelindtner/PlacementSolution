using Microsoft.AspNetCore.Mvc;
using PlacementTableApp.Services.Interfaces;

namespace PlacementTableApp.Controllers
{
    public class StandingUSController : Controller
    {
        private readonly IStandingService _standingUSService;
        private readonly ISportDataService _portDataService;

        public StandingUSController(IStandingService standingUSService, ISportDataService sportDataService)
        {
            _standingUSService = standingUSService;
            _portDataService = sportDataService;
        }

        [Route("StandingUS/{league?}/{division?}")]
        public async Task<IActionResult> Index(string league = null, string division = null)
        {
            ViewData["FilterLeague"] ??= league;
            ViewData["FilterDivision"] ??= division;

            var data = await _portDataService.GetStandingsUSAsync(league, division);
            return View(data);
        }
    }
}