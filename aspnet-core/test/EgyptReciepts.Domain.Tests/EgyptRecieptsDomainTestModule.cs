using EgyptReciepts.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EgyptReciepts;

[DependsOn(
    typeof(EgyptRecieptsEntityFrameworkCoreTestModule)
    )]
public class EgyptRecieptsDomainTestModule : AbpModule
{

}
