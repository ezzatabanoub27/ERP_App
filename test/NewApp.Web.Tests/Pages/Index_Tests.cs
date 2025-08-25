using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace NewApp.Pages;

[Collection(NewAppTestConsts.CollectionDefinitionName)]
public class Index_Tests : NewAppWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
