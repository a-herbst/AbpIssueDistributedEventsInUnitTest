using Volo.Abp.Modularity;

namespace AbpIssueDistributedEventsInUnitTest;

[DependsOn(
    typeof(AbpIssueDistributedEventsInUnitTestApplicationModule),
    typeof(AbpIssueDistributedEventsInUnitTestDomainTestModule)
)]
public class AbpIssueDistributedEventsInUnitTestApplicationTestModule : AbpModule
{

}
