namespace LugxGaming.Database.ViewModels;

public class CreateGameViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public IFormFile File { get; set; }
}
