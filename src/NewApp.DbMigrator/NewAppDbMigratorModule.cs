using NewApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace NewApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NewAppEntityFrameworkCoreModule),
    typeof(NewAppApplicationContractsModule)
)]
public class NewAppDbMigratorModule : AbpModule
{
}
