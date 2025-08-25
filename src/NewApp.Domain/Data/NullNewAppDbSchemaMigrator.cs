using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace NewApp.Data;

/* This is used if database provider does't define
 * INewAppDbSchemaMigrator implementation.
 */
public class NullNewAppDbSchemaMigrator : INewAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
