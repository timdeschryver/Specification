namespace Ardalis.Specification.UnitTests.Fixture.Specs;

public class StoreByIdIgnoreAutoIncludeIncludeAddressSpec : Specification<Store>, ISingleResultSpecification<Store>
{
    public StoreByIdIgnoreAutoIncludeIncludeAddressSpec(int id)
    {
        Query.Where(x => x.Id == id)
            .Include(x => x.Address)
            .IgnoreAutoIncludes();
    }
}
