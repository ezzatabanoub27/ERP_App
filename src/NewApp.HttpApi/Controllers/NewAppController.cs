using NewApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace NewApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NewAppController : AbpControllerBase
{
    protected NewAppController()
    {
        LocalizationResource = typeof(NewAppResource);
    }
}
