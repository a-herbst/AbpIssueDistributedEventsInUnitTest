using Volo.Abp.Domain.Entities.Events.Distributed;

namespace AbpIssueDistributedEventsInUnitTest.Issue22053.Events;

public class SampleEto : EtoBase
{
    /// <summary>
    /// Order number indicating the order in which multiple SampleEtos were published.
    /// </summary>
    public required int Order;
}
