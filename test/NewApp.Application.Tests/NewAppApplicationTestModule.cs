using Volo.Abp.Modularity;

namespace NewApp;

[DependsOn(
    typeof(NewAppApplicationModule),
    typeof(NewAppDomainTestModule)
)]
public class NewAppApplicationTestModule : AbpModule
{

}
