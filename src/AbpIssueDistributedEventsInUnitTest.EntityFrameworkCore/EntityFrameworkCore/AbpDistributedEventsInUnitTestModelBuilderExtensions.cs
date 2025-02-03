using AbpIssueDistributedEventsInUnitTest.Issue22053.MyAggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace AbpIssueDistributedEventsInUnitTest.EntityFrameworkCore;
public static class AbpDistributedEventsInUnitTestModelBuilderExtensions
{
    public static void ConfigureMyAggregate(this ModelBuilder builder)
    {
        builder.Entity<MyAggregate>(builder =>
        {
            builder.ToTable(AbpIssueDistributedEventsInUnitTestConsts.DbTablePrefix + "MyAggregate", AbpIssueDistributedEventsInUnitTestConsts.DbSchema);
            builder.ConfigureByConvention();
        });
    }
}
