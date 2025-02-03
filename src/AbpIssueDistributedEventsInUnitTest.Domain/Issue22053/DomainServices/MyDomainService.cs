using AbpIssueDistributedEventsInUnitTest.Issue22053.Events;
using AbpIssueDistributedEventsInUnitTest.Issue22053.MyAggregates;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Distributed;

namespace AbpIssueDistributedEventsInUnitTest.Issue22053.DomainServices;

public class MyDomainService : DomainService
{
    private IDistributedEventBus DistributedEventBus
        => LazyServiceProvider.GetRequiredService<IDistributedEventBus>();

    public virtual async Task MyUseCaseAsync(MyAggregate aggregate, int order)
    {
        await DistributedEventBus.PublishAsync(new SampleEto() { Order = order });
        aggregate.MyUseCase(order + 1);
    }
}
