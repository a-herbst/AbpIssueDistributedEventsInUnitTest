using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpIssueDistributedEventsInUnitTest.Data;
using Volo.Abp.DependencyInjection;

namespace AbpIssueDistributedEventsInUnitTest.EntityFrameworkCore;

public class EntityFrameworkCoreAbpIssueDistributedEventsInUnitTestDbSchemaMigrator
    : IAbpIssueDistributedEventsInUnitTestDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAbpIssueDistributedEventsInUnitTestDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AbpIssueDistributedEventsInUnitTestDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpIssueDistributedEventsInUnitTestDbContext>()
            .Database
            .MigrateAsync();
    }
}
