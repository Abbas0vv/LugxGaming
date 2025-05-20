using LugxGaming.Database.Interfaces;
using LugxGaming.Database.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LugxGaming.Areas.Admin.Controllers;

[Area(nameof(Admin))]
public class DashboardController : Controller
{
    private readonly IGameRepository _gameRepository;

    public DashboardController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var games = _gameRepository.GetAll();
        return View(games);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateGameViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _gameRepository.Insert(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int? id)
    {
        var game = _gameRepository.GetById(id);
        var model = new UpdateGameViewModel()
        {
            Name = game.Name,
            Description = game.Description,
            Price = game.Price,
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Update(int? id, UpdateGameViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _gameRepository.Update(id, model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        _gameRepository.RemoveById(id);
        return RedirectToAction(nameof(Index));
    }
}
