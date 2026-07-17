using Microsoft.AspNetCore.Mvc;
using PlacementTableApp.Services.Interfaces;

namespace PlacementTableApp.Controllers
{
    public class StandingUSController : Controller
    {
        private readonly IStandingService _standingUSService;

        public StandingUSController(IStandingService standingUSService)
        {
            _standingUSService = standingUSService;
        }

        [Route("StandingUS/{league?}/{division?}")]
        public async Task<IActionResult> Index(string league = null, string division = null)
        {
            ViewData["FilterLeague"] ??= league;
            ViewData["FilterDivision"] ??= division;

            var data = await _standingUSService.GetStandingsUSAsync(league, division);
            return View(data);
        }
    }
}