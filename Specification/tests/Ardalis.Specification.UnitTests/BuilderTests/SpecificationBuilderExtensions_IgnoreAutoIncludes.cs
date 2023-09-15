namespace Ardalis.Specification.UnitTests.BuilderTests;

public class SpecificationBuilderExtensions_IgnoreAutoIncludes
{
  [Fact]
  public void DoesNothing_GivenSpecWithoutIgnoreAutoIncludes()
  {
    var spec = new StoreEmptySpec();

    spec.IgnoreAutoIncludes.Should().Be(false);
  }

  [Fact]
  public void DoesNothing_GivenAsIgnoreAutoIncludesWithFalseCondition()
  {
    var spec = new CompanyByIdWithFalseConditions(1);

    spec.IgnoreAutoIncludes.Should().Be(false);
  }

  [Fact]
  public void FlagsAsNoTracking_GivenSpecWithIgnoreAutoIncludes()
  {
    var spec = new CompanyByIdWithIgnoreAutoIncludes(1);

    spec.IgnoreAutoIncludes.Should().Be(true);
  }
}
