using System.Threading.Tasks;

namespace EgyptReciepts.Data;

public interface IEgyptRecieptsDbSchemaMigrator
{
    Task MigrateAsync();
}
