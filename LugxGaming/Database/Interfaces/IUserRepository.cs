using LugxGaming.Database.ViewModels;

namespace LugxGaming.Database.Interfaces;

public interface IUserRepository
{
    public async Task RegisterUser(RegisterViewModel model)
    {
        return;
    }
    public async Task LoginUser(LoginViewModel model)
    {
        return;
    }
    public async Task LogOutUser()
    {
        return;
    }
}
