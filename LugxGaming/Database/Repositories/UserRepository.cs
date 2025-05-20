using LugxGaming.Database.DomainModels.Account;
using LugxGaming.Database.Interfaces;
using LugxGaming.Database.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LugxGaming.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<LugxUser> _userManager;
    private readonly SignInManager<LugxUser> _signInManager;

    public UserRepository(UserManager<LugxUser> userManager, SignInManager<LugxUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task RegisterUser(RegisterViewModel model)
    {
        var user = new LugxUser()
        {
            Name = model.Name,
            Surname = model.Surname,
            UserName = model.Username,
            Email = model.Email,
        };

        var result = await _userManager.CreateAsync(user, model.Password);
    }

    public async Task LoginUser(LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        var result = await _userManager.CheckPasswordAsync(user, model.Password);

        if (result) 
           await _signInManager.SignInAsync(user, isPersistent: true);
    }

    public async Task LogOutUser()
    {
        await _signInManager.SignOutAsync();
    }
}
