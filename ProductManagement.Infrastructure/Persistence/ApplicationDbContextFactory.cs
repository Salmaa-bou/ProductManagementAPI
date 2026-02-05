using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProductManagement.Infrastructure.Persistence;

namespace ProductManagement.Infrastructure.Persistence;

// This factory is ONLY used by EF Core tools (migrations)
// It bypasses dependency injection and provides a hardcoded connection string
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        // Hardcoded connection string for design-time (migrations)
        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=ProductManagementDb;Trusted_Connection=true;MultipleActiveResultSets=true");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}