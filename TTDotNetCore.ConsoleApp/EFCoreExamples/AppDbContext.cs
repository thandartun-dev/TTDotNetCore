using Microsoft.EntityFrameworkCore;
using TTDotNetCore.ConsoleApp.Dtos;
using TTDotNetCore.ConsoleApp.Services;

namespace TTDotNetCore.ConsoleApp.EFCoreExamples;

internal class AppDbContext : DbContext // DbContext - connect c# and database
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }
    public DbSet<BlogDto> Blogs { get; set; }
}
