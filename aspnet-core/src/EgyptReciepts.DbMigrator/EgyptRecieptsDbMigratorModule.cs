using EgyptReciepts.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace EgyptReciepts.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EgyptRecieptsEntityFrameworkCoreModule),
    typeof(EgyptRecieptsApplicationContractsModule)
)]
public class EgyptRecieptsDbMigratorModule : AbpModule
{
}
