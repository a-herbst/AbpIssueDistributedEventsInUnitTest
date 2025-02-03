using AbpIssueDistributedEventsInUnitTest.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpIssueDistributedEventsInUnitTest.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpIssueDistributedEventsInUnitTestController : AbpControllerBase
{
    protected AbpIssueDistributedEventsInUnitTestController()
    {
        LocalizationResource = typeof(AbpIssueDistributedEventsInUnitTestResource);
    }
}
