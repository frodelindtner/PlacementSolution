using Microsoft.AspNetCore.Mvc;
using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Services.Interfaces;

namespace PlacementTableApp.Controllers
{
    public class ResultController : Controller
    {
        private readonly IResultService _service;

        public ResultController(IResultService service)
        {
            _service = service;
        }

        // List all results
        public async Task<IActionResult> Index()
        {
            var results = await _service.GetAllAsync();
            return View(results);
        }

        //https://localhost:7053/Team/AddResult?teamId=18
        //[Route("/Result/AddResult/[teamId]")]
        public IActionResult AddResult(int teamId)
        {
            var result = _service.GetByTeamId(teamId).Result;
            if (result == null) return NotFound();
            var view = Helpers.Mappers.ViewModel.ConvertResult(result);
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddResult(ResultView model)
        {
            if (!ModelState.IsValid) return View(model);

            await _service.UpdateTeamAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: Result/Create
        public IActionResult Create()
        {
            return View(new ResultView());
        }

        // POST: Result/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResultView model)
        {
            if (!ModelState.IsValid) return View(model);

            await _service.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
