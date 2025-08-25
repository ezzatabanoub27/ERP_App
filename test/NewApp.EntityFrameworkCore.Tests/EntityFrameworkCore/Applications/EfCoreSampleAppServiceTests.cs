using NewApp.Samples;
using Xunit;

namespace NewApp.EntityFrameworkCore.Applications;

[Collection(NewAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<NewAppEntityFrameworkCoreTestModule>
{

}
