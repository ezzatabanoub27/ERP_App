using System.Threading.Tasks;

namespace NewApp.Data;

public interface INewAppDbSchemaMigrator
{
    Task MigrateAsync();
}
