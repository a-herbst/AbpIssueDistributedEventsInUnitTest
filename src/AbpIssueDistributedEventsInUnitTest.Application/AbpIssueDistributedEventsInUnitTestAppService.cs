using System;
using System.Collections.Generic;
using System.Text;
using AbpIssueDistributedEventsInUnitTest.Localization;
using Volo.Abp.Application.Services;

namespace AbpIssueDistributedEventsInUnitTest;

/* Inherit your application services from this class.
 */
public abstract class AbpIssueDistributedEventsInUnitTestAppService : ApplicationService
{
    protected AbpIssueDistributedEventsInUnitTestAppService()
    {
        LocalizationResource = typeof(AbpIssueDistributedEventsInUnitTestResource);
    }
}
