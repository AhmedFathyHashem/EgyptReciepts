using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EgyptReciepts.Data;

/* This is used if database provider does't define
 * IEgyptRecieptsDbSchemaMigrator implementation.
 */
public class NullEgyptRecieptsDbSchemaMigrator : IEgyptRecieptsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
