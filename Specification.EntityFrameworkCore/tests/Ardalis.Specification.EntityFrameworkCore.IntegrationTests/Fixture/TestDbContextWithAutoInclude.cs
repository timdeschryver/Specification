using Ardalis.Specification.UnitTests.Fixture.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ardalis.Specification.EntityFrameworkCore.IntegrationTests.Fixture;

public class TestDbContextWithAutoInclude : TestDbContext
{
    public TestDbContextWithAutoInclude(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Store>().Navigation(s => s.Address).AutoInclude();
        modelBuilder.Entity<Store>().Navigation(s => s.Company).AutoInclude();
        modelBuilder.Entity<Store>().Navigation(s => s.Products).AutoInclude();
    }
}

