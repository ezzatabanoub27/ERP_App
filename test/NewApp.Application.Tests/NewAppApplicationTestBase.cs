using Volo.Abp.Modularity;

namespace NewApp;

public abstract class NewAppApplicationTestBase<TStartupModule> : NewAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
