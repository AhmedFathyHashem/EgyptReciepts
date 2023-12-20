using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EgyptReciepts.Data;
using Volo.Abp.DependencyInjection;

namespace EgyptReciepts.EntityFrameworkCore;

public class EntityFrameworkCoreEgyptRecieptsDbSchemaMigrator
    : IEgyptRecieptsDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreEgyptRecieptsDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the EgyptRecieptsDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<EgyptRecieptsDbContext>()
            .Database
            .MigrateAsync();
    }
}
