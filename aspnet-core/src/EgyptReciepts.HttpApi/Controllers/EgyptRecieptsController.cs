using EgyptReciepts.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EgyptReciepts.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EgyptRecieptsController : AbpControllerBase
{
    protected EgyptRecieptsController()
    {
        LocalizationResource = typeof(EgyptRecieptsResource);
    }
}
