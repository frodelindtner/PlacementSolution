using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PlacementTableApp.Models.DTOs.Output;
using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Services.Interfaces;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;

namespace PlacementTableApp.Controllers.Api
{
    public class ApiStandingController : Controller
    {
        private readonly IStandingService _standingService;
        private enum StandingFilter { noFilter, league, division, leagueAndDivision }
        public ApiStandingController(IStandingService standingService) 
        { 
            _standingService = standingService;
        }

        [HttpGet]
        [Route("/api/standings/")]
        [Route("/api/standings/{league}/")]
        [Route("/api/standings/{league}/{division}")]
        public IActionResult GetStandings(string league = null, string division = null)
        {
            var standingFilter = StandingFilter.noFilter;
            var standings = _standingService.GetStandingLocalAsync().Result;

            if (league != null) standingFilter = StandingFilter.league;
            if (division != null) standingFilter = StandingFilter.division;
            if ((division != null) && (league != null))
            {
                standingFilter = StandingFilter.leagueAndDivision;
            }
            var fStandings = standings.Select(s => Helpers.Mappers.Output.ConvertStanding(s));

            switch (standingFilter)
            {
                case (StandingFilter.noFilter): break;
                case (StandingFilter.league):
                    fStandings = fStandings.Where(x => x.League == league);
                    break;
                case (StandingFilter.division):
                    fStandings = fStandings.Where(x => x.Division == division);
                    break;
                case (StandingFilter.leagueAndDivision):
                    fStandings = fStandings.Where(x => (x.League == league) && (x.Division == division));
                    break;
            }
            var output = fStandings;

            return Ok(output);
        }
    }
}
