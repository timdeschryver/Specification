namespace Ardalis.Specification.EntityFrameworkCore.IntegrationTests.Fixture;

public class DataBaseFixtureWithAutoInclude : DatabaseFixtureBase<TestDbContextWithAutoInclude>
{
    protected override TestDbContextWithAutoInclude CreateDbContext()
    {
        return new TestDbContextWithAutoInclude(DbContextOptions);
    }
}

