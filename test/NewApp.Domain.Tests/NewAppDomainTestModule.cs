using Volo.Abp.Modularity;

namespace NewApp;

[DependsOn(
    typeof(NewAppDomainModule),
    typeof(NewAppTestBaseModule)
)]
public class NewAppDomainTestModule : AbpModule
{

}
