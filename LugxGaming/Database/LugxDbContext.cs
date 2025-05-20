using LugxGaming.Database.DomainModels;
using LugxGaming.Database.DomainModels.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LugxGaming.Database;

public class LugxDbContext : IdentityDbContext<LugxUser, LugxRole, int>
{
    public LugxDbContext(DbContextOptions<LugxDbContext> options): base(options) { }

    public DbSet<Game> Games { get; set; }
}
