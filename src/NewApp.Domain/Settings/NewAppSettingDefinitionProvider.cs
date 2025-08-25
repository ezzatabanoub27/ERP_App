using Volo.Abp.Settings;

namespace NewApp.Settings;

public class NewAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(NewAppSettings.MySetting1));
    }
}
