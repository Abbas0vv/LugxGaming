using Microsoft.AspNetCore.Identity;

namespace LugxGaming.Database.DomainModels.Account;

public class LugxUser : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
