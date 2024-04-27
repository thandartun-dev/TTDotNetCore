using Microsoft.EntityFrameworkCore;

namespace TTDotNetCore.ConsoleApp;

internal class AppDbContext : DbContext // DbContext - connect c# and database
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }
    public DbSet<BlogDto> Blogs { get; set; }
}
