using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace EgyptReciepts;

[Dependency(ReplaceServices = true)]
public class EgyptRecieptsBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EgyptReciepts";
}
