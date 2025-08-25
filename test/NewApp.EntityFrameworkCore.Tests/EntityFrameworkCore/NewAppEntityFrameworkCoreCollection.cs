using Xunit;

namespace NewApp.EntityFrameworkCore;

[CollectionDefinition(NewAppTestConsts.CollectionDefinitionName)]
public class NewAppEntityFrameworkCoreCollection : ICollectionFixture<NewAppEntityFrameworkCoreFixture>
{

}
