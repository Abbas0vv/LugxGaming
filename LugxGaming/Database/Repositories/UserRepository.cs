using LugxGaming.Database.DomainModels.Account;
using LugxGaming.Database.Interfaces;
using LugxGaming.Database.ViewModels;
using LugxGaming.Helpers.Enums;
using Microsoft.AspNetCore.Identity;

namespace LugxGaming.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<LugxUser> _userManager;
    private readonly SignInManager<LugxUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRepository(UserManager<LugxUser> userManager, SignInManager<LugxUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
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
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, Role.Admin.ToString());

            await _signInManager.SignInAsync(user, true);
        }
    }

    public async Task LoginUser(LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user is not null)
        {
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (result)
                await _signInManager.SignInAsync(user, isPersistent: true);
        }

    }

    public async Task LogOutUser()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task CreateRole()
    {
        foreach (var item in Enum.GetValues(typeof(Role)))
        {
            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = item.ToString()
            });
        }
    }
}
