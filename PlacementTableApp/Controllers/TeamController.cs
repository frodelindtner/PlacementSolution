using Microsoft.AspNetCore.Mvc;
using PlacementTableApp.Models.DTOs;
using PlacementTableApp.Services;
using PlacementTableApp.Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PlacementTableApp.Controllers
{
    public class TeamController : Controller
    {
        private static List<ResultDTO> _results = new();
        private static List<TeamDTO> _teams = new();

        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // Select all
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
        public IActionResult Create(TeamDTO team)
        {
            if (!ModelState.IsValid)
                return View(team);

            var nextId = _teams.Any() ? _teams.Max(t => t.Id) + 1 : 1;
            var newTeam = new TeamDTO(nextId, team.Season, team.City, team.Name, team.Division, team.League);
            _teams.Add(newTeam);
            return RedirectToAction(nameof(IndexAsync));
        }

        // Update/Edit - GET
        public IActionResult Edit(int id)
        {
            var team = _teams.FirstOrDefault(t => t.Id == id);
            if (team == null) return NotFound();
            return View(team);
        }

        // Update/Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TeamDTO team)
        {
            if (!ModelState.IsValid)
                return View(team);

            var existing = _teams.FirstOrDefault(t => t.Id == team.Id);
            if (existing == null) return NotFound();

            // Replace the item with new instance (Team has read-only Id)
            var index = _teams.IndexOf(existing);
            _teams[index] = new TeamDTO(existing.Id, team.Season, team.City, team.Name, team.Division, team.League);

            return RedirectToAction(nameof(IndexAsync));
        }

        // Add Result - GET
        public IActionResult AddResult(int teamId)
        {
            var team = _teams.FirstOrDefault(t => t.Id == teamId);
            if (team == null) return NotFound();
            var model = new ResultDTO(0, teamId.ToString(), 0, 0);
            ViewBag.TeamName = team.Name;
            return View(model);
        }

        // Add Result - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddResult(ResultDTO result)
        {
            if (!ModelState.IsValid)
                return View(result);

            var nextId = _results.Any() ? _results.Max(r => r.Id) + 1 : 1;
            var res = new ResultDTO(nextId, result.TeamId.ToString(), result.Wins, result.Losses);
            _results.Add(res);
            return RedirectToAction(nameof(IndexAsync));
        }
    }
}
