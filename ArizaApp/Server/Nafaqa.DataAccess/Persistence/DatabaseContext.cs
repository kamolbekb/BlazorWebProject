using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Nafaqa.Core.Entities;

namespace Nafaqa.DataAccess.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public DbSet<Petition> Petitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
