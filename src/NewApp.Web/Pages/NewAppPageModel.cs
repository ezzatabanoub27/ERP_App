using NewApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace NewApp.Web.Pages;

public abstract class NewAppPageModel : AbpPageModel
{
    protected NewAppPageModel()
    {
        LocalizationResourceType = typeof(NewAppResource);
    }
}
