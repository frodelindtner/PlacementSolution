using Microsoft.AspNetCore.Mvc;
using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PlacementTableApp.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> CreateTeamsAuto()
        {
            var teams = new List<TeamView>
            {
                new() { Id = 0, City = "Hørsholm", Division = "1. Div", League = "Øst", Name = "Hurricanes", Season = "2026" },
                new() { Id = 0, City = "Kokkedal", Division = "1. Div", League = "Øst", Name = "Pirats", Season = "2026" },
                new() { Id = 0, City = "Lyngby", Division = "1. Div", League = "Øst", Name = "Jokers", Season = "2026" },
                new() { Id = 0, City = "Ballerup", Division = "1. Div", League = "Øst", Name = "Vandals", Season = "2026"},
                new() { Id = 0, City = "Odense", Division = "1. Div", League = "Central", Name = "Wolwes", Season = "2026"},
                new() { Id = 0, City = "Odense", Division = "1. Div", League = "Central", Name = "Giants", Season = "2026"},
                new() { Id = 0, City = "Øksendrup", Division = "1. Div", League = "Central", Name = "Oysters", Season = "2026"},
                new() { Id = 0, City = "Aarhus", Division = "1. Div", League = "Vest", Name = "Royals", Season = "2026"},
                new() { Id = 0, City = "Herning", Division = "1. Div", League = "Vest", Name = "Trolls", Season = "2026"}
            };

            foreach (var team in teams) {
                _ = _teamService.AddTeamAsync(team);
            }
            return RedirectToAction(nameof(Index));
        }

        // Select all
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var list = await _teamService.GetTeamsAsync();
            return View(list);
        }

        // Create - GET
        public IActionResult Create()
        {
            return View();
        }

        // Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamView team)
        {
            if (!ModelState.IsValid) return View(team);
            var newTeam = new TeamView(0, team.Season, team.City, team.Name, team.Division, team.League);
            await _teamService.AddTeamAsync(newTeam);

            return RedirectToAction(nameof(Index));
        }

        // Update/Edit - GET
        [Route("/Team/Edit/{id?}")]
        public IActionResult Edit(int id)
        {
            var team = _teamService.GetTeamByIdAsync(id).Result;
            if (team == null) return NotFound();

            return View(team);
        }

        // Update/Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Team/Edit/{id?}")]
        public IActionResult Edit(TeamView team, int id)
        {
            if (!ModelState.IsValid) return View(team);
            if (team.Id != id) return NotFound();
            var existing = _teamService.GetTeamByIdAsync(team.Id);
            if (existing == null) return NotFound();
            var result = _teamService.UpdateTeamAsync(team);

            return RedirectToAction(nameof(Index));
        }

        [Route("/Team/Delete/{teamId?}")]
        public IActionResult Delete(int teamId)
        {
            var team = _teamService.GetTeamByIdAsync(teamId);
            if (team == null) return NotFound();
            _teamService.DeleteTeamAsync(teamId);

            return RedirectToAction(nameof(Index));
        }
        
    }
}
