using AbpIssueDistributedEventsInUnitTest.Issue22053.Events;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace AbpIssueDistributedEventsInUnitTest.Issue22053.EventHandlers;

public class SampleEventHandler : IDistributedEventHandler<SampleEto>, ISingletonDependency
{
    public ICollection<SampleEto> EventsHandled = [];

    public Task HandleEventAsync(SampleEto eventData)
    {
        EventsHandled.Add(eventData);

        return Task.CompletedTask;
    }
}
