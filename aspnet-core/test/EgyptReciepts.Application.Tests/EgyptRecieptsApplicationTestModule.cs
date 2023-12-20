using Volo.Abp.Modularity;

namespace EgyptReciepts;

[DependsOn(
    typeof(EgyptRecieptsApplicationModule),
    typeof(EgyptRecieptsDomainTestModule)
    )]
public class EgyptRecieptsApplicationTestModule : AbpModule
{

}
