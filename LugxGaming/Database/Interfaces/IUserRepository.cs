using LugxGaming.Database.ViewModels;

namespace LugxGaming.Database.Interfaces;

public interface IUserRepository
{
    Task RegisterUser(RegisterViewModel model);
    Task LoginUser(LoginViewModel model);
    Task LogOutUser();
    Task CreateRole();
}
