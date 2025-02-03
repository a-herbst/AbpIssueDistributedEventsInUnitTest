using AbpIssueDistributedEventsInUnitTest.Issue22053.DomainServices;
using AbpIssueDistributedEventsInUnitTest.Issue22053.EventHandlers;
using AbpIssueDistributedEventsInUnitTest.Issue22053.Events;
using AbpIssueDistributedEventsInUnitTest.Issue22053.MyAggregates;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Guids;
using Volo.Abp.Uow;
using Xunit;

namespace AbpIssueDistributedEventsInUnitTest.EntityFrameworkCore.Issue22053.DomainServices;
public class MyDomainServiceTest : AbpIssueDistributedEventsInUnitTestEntityFrameworkCoreTestBase
{
    [Fact]
    public async Task HandleEventAsync_should_handle_DistributedEvents_in_the_same_order_they_have_been_published_within_a_uow()
    {
        // Arrange
        var myDomainService = GetRequiredService<MyDomainService>();

        var myAggregateRepository = GetRequiredService<IRepository<MyAggregate, Guid>>();

        var guidGenerator = GetRequiredService<IGuidGenerator>();
        Guid id = guidGenerator.Create();

        await WithUnitOfWorkAsync(
            new AbpUnitOfWorkOptions() { IsTransactional = true },
            async () =>
            {
                var myAggregate = await myAggregateRepository.InsertAsync(new MyAggregate(id));
            });

        // Act
        await WithUnitOfWorkAsync(
            new AbpUnitOfWorkOptions() { IsTransactional = true },
            async () =>
            {
                var myAggregate = await myAggregateRepository.GetAsync(id);

                await myDomainService.MyUseCaseAsync(myAggregate, 1);
                await myDomainService.MyUseCaseAsync(myAggregate, 3);
                await myDomainService.MyUseCaseAsync(myAggregate, 5);

                await myAggregateRepository.UpdateAsync(myAggregate);
            }
        );

        // Assert
        var sampleEventHandler = GetRequiredService<SampleEventHandler>();

        sampleEventHandler.EventsHandled
            .Select(eto => eto.Order)
            .ShouldBe([1, 2, 3, 4, 5, 6]);
    }

    protected override void AfterAddApplication(IServiceCollection services)
    {
        base.AfterAddApplication(services);

        services.Add(new(typeof(IDistributedEventHandler<SampleEto>), new SampleEventHandler()));
    }
}