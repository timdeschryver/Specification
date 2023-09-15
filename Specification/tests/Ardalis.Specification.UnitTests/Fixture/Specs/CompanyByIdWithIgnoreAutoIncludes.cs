namespace Ardalis.Specification.UnitTests.Fixture.Specs;

public class CompanyByIdWithIgnoreAutoIncludes : Specification<Company>, ISingleResultSpecification
{
    public CompanyByIdWithIgnoreAutoIncludes(int id)
    {
        Query.Where(company => company.Id == id)
            .Include(x => x.Stores)
            .ThenInclude(x => x.Products)
            .IgnoreAutoIncludes();
    }
}
