using NewApp.Localization;
using Volo.Abp.Application.Services;

namespace NewApp;

/* Inherit your application services from this class.
 */
public abstract class NewAppAppService : ApplicationService
{
    protected NewAppAppService()
    {
        LocalizationResource = typeof(NewAppResource);
    }
}
