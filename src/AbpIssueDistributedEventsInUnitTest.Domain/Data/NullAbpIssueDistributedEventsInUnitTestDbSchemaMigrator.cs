using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpIssueDistributedEventsInUnitTest.Data;

/* This is used if database provider does't define
 * IAbpIssueDistributedEventsInUnitTestDbSchemaMigrator implementation.
 */
public class NullAbpIssueDistributedEventsInUnitTestDbSchemaMigrator : IAbpIssueDistributedEventsInUnitTestDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
