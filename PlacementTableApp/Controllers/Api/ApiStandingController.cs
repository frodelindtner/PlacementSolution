using System.Web.Http;
using PlacementTableApp.Models.DTOs;

namespace PlacementTableApp.Controllers.Api
{
    public class ApiStandingController : ApiController
    {
        public ApiStandingController() { }

        [HttpGet]
        [Route("api/standings")]
        public IHttpActionResult GetStandings()
        {
            // Sample data for demonstration purposes
            var standings = new List<Standing>()
            {
                new("2024", "Regular", 1, "New York", "Yankees", "AL", "East", 95, 67, 50),
                new("2024", "Regular", 2, "Los Angeles", "Dodgers", "NL", "West", 92, 70, 48),
                new("2024", "Regular", 3, "Chicago", "Cubs", "NL", "Central", 88, 74, 45),

            };
            return Ok(standings);
        }
    }
}
