using EgyptReciepts.Localization;
using Volo.Abp.Application.Services;

namespace EgyptReciepts;

/* Inherit your application services from this class.
 */
public abstract class EgyptRecieptsAppService : ApplicationService
{
    protected EgyptRecieptsAppService()
    {
        LocalizationResource = typeof(EgyptRecieptsResource);
    }
}
