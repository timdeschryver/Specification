using Xunit;

namespace Ardalis.Specification.EntityFrameworkCore.IntegrationTests.Fixture.Collections;

[CollectionDefinition("ReadCollectionWithGlobalAutoInclude")]
public class ReadCollectionWitGlobalAutoInclude : ICollectionFixture<DataBaseFixtureWithAutoInclude>
{
    public ReadCollectionWitGlobalAutoInclude()
    {

    }
}
