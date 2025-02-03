using Volo.Abp.Modularity;

namespace AbpIssueDistributedEventsInUnitTest;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpIssueDistributedEventsInUnitTestDomainTestBase<TStartupModule> : AbpIssueDistributedEventsInUnitTestTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
