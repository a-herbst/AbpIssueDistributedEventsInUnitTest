using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpIssueDistributedEventsInUnitTest;

[Dependency(ReplaceServices = true)]
public class AbpIssueDistributedEventsInUnitTestBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpIssueDistributedEventsInUnitTest";
}
