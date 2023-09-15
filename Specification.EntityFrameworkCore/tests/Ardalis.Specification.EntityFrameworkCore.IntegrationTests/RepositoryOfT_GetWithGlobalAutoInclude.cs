using Ardalis.Specification.EntityFrameworkCore.IntegrationTests.Fixture;
using Ardalis.Specification.UnitTests.Fixture.Entities;
using Ardalis.Specification.UnitTests.Fixture.Entities.Seeds;
using Ardalis.Specification.UnitTests.Fixture.Specs;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ardalis.Specification.EntityFrameworkCore.IntegrationTests;

[Collection("ReadCollectionWithGlobalAutoInclude")]
public class RepositoryOfT_GetWithGlobalAutoInclude : RepositoryOfT_GetWithGlobalAutoInclude_TestKit
{
    public RepositoryOfT_GetWithGlobalAutoInclude(DataBaseFixtureWithAutoInclude fixture) : base(fixture, SpecificationEvaluator.Default)
    {
    }
}

public abstract class RepositoryOfT_GetWithGlobalAutoInclude_TestKit
{
    private readonly DbContextOptions<TestDbContextWithAutoInclude> _dbContextOptions;
    private readonly ISpecificationEvaluator _specificationEvaluator;

    protected RepositoryOfT_GetWithGlobalAutoInclude_TestKit(DataBaseFixtureWithAutoInclude fixture, ISpecificationEvaluator specificationEvaluator)
    {
        _dbContextOptions = fixture.DbContextOptions;
        _specificationEvaluator = specificationEvaluator;
    }

    [Fact]
    public virtual async Task ReturnsStoreWithNestedEntities_GivenNavigationPropertyUsesGlobalInclude()
    {
        using var dbContext = new TestDbContextWithAutoInclude(_dbContextOptions);
        var repo = new Repository<Store>(dbContext, _specificationEvaluator);

        var result = await repo.GetByIdAsync(StoreSeed.VALID_STORE_ID);

        result.Should().NotBeNull();
        result!.Name.Should().Be(StoreSeed.VALID_STORE_NAME);
        result!.Address.Should().NotBeNull();
        result!.Company.Should().NotBeNull();
        result!.Products.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public virtual async Task ReturnsStoreWithoutNestedEntities_GivenGlobalAutoIncludesAreIgnored()
    {
        using var dbContext = new TestDbContextWithAutoInclude(_dbContextOptions);
        var repo = new Repository<Store>(dbContext, _specificationEvaluator);

        var result = await repo.SingleOrDefaultAsync(new StoreByIdIgnoreAutoIncludeSpec(StoreSeed.VALID_STORE_ID));

        result.Should().NotBeNull();
        result!.Name.Should().Be(StoreSeed.VALID_STORE_NAME);
        result!.Address.Should().BeNull();
        result!.Company.Should().BeNull();
        result!.Products.Should().HaveCount(0);
    }

    [Fact]
    public virtual async Task ReturnsStoreWithAddress_GivenGlobalAutoIncludesAreIgnoredAndAddressIsIncluded()
    {
        using var dbContext = new TestDbContextWithAutoInclude(_dbContextOptions);
        var repo = new Repository<Store>(dbContext, _specificationEvaluator);

        var result = await repo.SingleOrDefaultAsync(new StoreByIdIgnoreAutoIncludeIncludeAddressSpec(StoreSeed.VALID_STORE_ID));

        result.Should().NotBeNull();
        result!.Name.Should().Be(StoreSeed.VALID_STORE_NAME);
        result!.Address.Should().NotBeNull();
        result!.Company.Should().BeNull();
        result!.Products.Should().HaveCount(0);
    }
}
