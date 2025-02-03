using Volo.Abp.Modularity;

namespace AbpIssueDistributedEventsInUnitTest;

[DependsOn(
    typeof(AbpIssueDistributedEventsInUnitTestDomainModule),
    typeof(AbpIssueDistributedEventsInUnitTestTestBaseModule)
)]
public class AbpIssueDistributedEventsInUnitTestDomainTestModule : AbpModule
{

}
