﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpIssueDistributedEventsInUnitTest.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AbpIssueDistributedEventsInUnitTestDbContextFactory : IDesignTimeDbContextFactory<AbpIssueDistributedEventsInUnitTestDbContext>
{
    public AbpIssueDistributedEventsInUnitTestDbContext CreateDbContext(string[] args)
    {
        AbpIssueDistributedEventsInUnitTestEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AbpIssueDistributedEventsInUnitTestDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new AbpIssueDistributedEventsInUnitTestDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AbpIssueDistributedEventsInUnitTest.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
