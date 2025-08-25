using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using NewApp.Localization;

namespace NewApp.Web;

[Dependency(ReplaceServices = true)]
public class NewAppBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<NewAppResource> _localizer;

    public NewAppBrandingProvider(IStringLocalizer<NewAppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
