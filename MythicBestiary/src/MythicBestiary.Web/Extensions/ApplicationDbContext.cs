using MythicBestiary.Models;

namespace MythicBestiary.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Creature> Creatures => Set<Creature>();
}