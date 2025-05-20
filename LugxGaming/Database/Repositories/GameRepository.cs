using LugxGaming.Database.DomainModels;
using LugxGaming.Database.Interfaces;
using LugxGaming.Database.ViewModels;
using LugxGaming.Extentions;

namespace LugxGaming.Database.Repositories;

public class GameRepository : IGameRepository
{
    private readonly LugxDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private const string FOLDER_NAME = "Uploads/Game";

    public GameRepository(LugxDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public List<Game> GetAll()
    {
        return _context.Games.OrderBy(x => x.Id).ToList();
    }
    public List<Game> GetSome(int value)
    {
        if (value > GetAll().Count) return GetAll();
        return _context.Games.OrderBy(x => x.Id).Take(value).ToList();
    }

    public Game GetById(int? id)
    {
        return _context.Games.FirstOrDefault(g => g.Id == id);
    }

    public void Insert(CreateGameViewModel model)
    {
        var game = new Game()
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            ImageUrl = model.File.CreateFile(_webHostEnvironment.WebRootPath, FOLDER_NAME)
        };

        _context.Games.Add(game);
        _context.SaveChanges();
    }

    public void Update(int? id, UpdateGameViewModel model)
    {
        if (id is null) return;

        var game = GetById(id);
        game.Name = model.Name;
        game.Description = model.Description;
        game.Price = model.Price;

        if (model.File is not null)
            game.ImageUrl = model.File.UpdateFile(_webHostEnvironment.WebRootPath, FOLDER_NAME, game.ImageUrl);

        _context.Games.Update(game);
        _context.SaveChanges();
    }

    public void RemoveById(int? id)
    {
        if (id is null) return;
        var game = GetById(id);
        _context.Games.Remove(game);
        _context.SaveChanges();
    }
}
