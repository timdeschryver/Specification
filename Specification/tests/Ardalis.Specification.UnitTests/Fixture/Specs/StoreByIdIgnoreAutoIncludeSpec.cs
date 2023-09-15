namespace Ardalis.Specification.UnitTests.Fixture.Specs;

public class StoreByIdIgnoreAutoIncludeSpec : Specification<Store>, ISingleResultSpecification<Store>
{
    public StoreByIdIgnoreAutoIncludeSpec(int id)
    {
        Query.Where(x => x.Id == id)
            .IgnoreAutoIncludes();
    }
}
