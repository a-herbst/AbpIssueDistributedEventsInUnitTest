using System.Threading.Tasks;

namespace AbpIssueDistributedEventsInUnitTest.Data;

public interface IAbpIssueDistributedEventsInUnitTestDbSchemaMigrator
{
    Task MigrateAsync();
}
