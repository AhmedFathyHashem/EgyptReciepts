using Volo.Abp.Settings;

namespace EgyptReciepts.Settings;

public class EgyptRecieptsSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(EgyptRecieptsSettings.MySetting1));
    }
}
