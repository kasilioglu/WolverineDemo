using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DemoApi.Infrastructure.Persistence;

/// <summary>
/// Used by EF Core tools at design time (e.g. dotnet ef migrations add) when running with Infrastructure as startup project.
/// </summary>
public sealed class TaskDbContextFactory : IDesignTimeDbContextFactory<TaskDbContext>
{
    public TaskDbContext CreateDbContext(string[] args)
    {
        const string designTimeConnection = "Server=localhost,1433;Database=WolverineDemoDb;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;";

        var optionsBuilder = new DbContextOptionsBuilder<TaskDbContext>();
        optionsBuilder.UseSqlServer(designTimeConnection);
        return new TaskDbContext(optionsBuilder.Options);
    }
}
