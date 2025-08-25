using Volo.Abp.Modularity;

namespace NewApp;

/* Inherit from this class for your domain layer tests. */
public abstract class NewAppDomainTestBase<TStartupModule> : NewAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
