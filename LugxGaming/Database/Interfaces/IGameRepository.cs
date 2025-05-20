using LugxGaming.Database.DomainModels;
using LugxGaming.Database.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace LugxGaming.Database.Interfaces;

public interface IGameRepository
{
    public List<Game> GetAll();
    public List<Game> GetSome(int value);
    public Game GetById(int? id);
    public void Insert(CreateGameViewModel model);
    public void Update(int? id, UpdateGameViewModel model);
    public void RemoveById(int? id);
}
