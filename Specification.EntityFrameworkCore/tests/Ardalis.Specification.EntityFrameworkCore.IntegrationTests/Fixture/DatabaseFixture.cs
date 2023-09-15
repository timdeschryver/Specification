namespace Ardalis.Specification.EntityFrameworkCore.IntegrationTests.Fixture;

public class DatabaseFixture : DatabaseFixtureBase<TestDbContext>
{
    protected override TestDbContext CreateDbContext()
    {
        return new TestDbContext(DbContextOptions);
    }
}
