using NewApp.Samples;
using Xunit;

namespace NewApp.EntityFrameworkCore.Domains;

[Collection(NewAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<NewAppEntityFrameworkCoreTestModule>
{

}
