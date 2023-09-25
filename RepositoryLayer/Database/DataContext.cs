using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Databases.Configuration;

public sealed class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<int[]> SortedNumbers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    }
}