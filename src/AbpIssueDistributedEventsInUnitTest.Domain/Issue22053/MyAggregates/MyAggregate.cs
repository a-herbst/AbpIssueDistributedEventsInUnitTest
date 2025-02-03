using AbpIssueDistributedEventsInUnitTest.Issue22053.Events;
using System;
using Volo.Abp.Domain.Entities;

namespace AbpIssueDistributedEventsInUnitTest.Issue22053.MyAggregates;

public class MyAggregate : AggregateRoot<Guid>
{
    public MyAggregate(Guid id) : base(id)
    {
    }

    public void MyUseCase(int order)
    {
        AddDistributedEvent(new SampleEto() { Order = order });
    }
}
