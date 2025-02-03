using AbpIssueDistributedEventsInUnitTest.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpIssueDistributedEventsInUnitTest.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpIssueDistributedEventsInUnitTestEntityFrameworkCoreModule),
    typeof(AbpIssueDistributedEventsInUnitTestApplicationContractsModule)
    )]
public class AbpIssueDistributedEventsInUnitTestDbMigratorModule : AbpModule
{
}
