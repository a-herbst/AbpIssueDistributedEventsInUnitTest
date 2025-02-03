using AbpIssueDistributedEventsInUnitTest.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpIssueDistributedEventsInUnitTest.Permissions;

public class AbpIssueDistributedEventsInUnitTestPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpIssueDistributedEventsInUnitTestPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpIssueDistributedEventsInUnitTestPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpIssueDistributedEventsInUnitTestResource>(name);
    }
}
