using EgyptReciepts.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace EgyptReciepts.Permissions;

public class EgyptRecieptsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EgyptRecieptsPermissions.GroupName);

        myGroup.AddPermission(EgyptRecieptsPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(EgyptRecieptsPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(EgyptRecieptsPermissions.MyPermission1, L("Permission:MyPermission1"));

        var branchPermission = myGroup.AddPermission(EgyptRecieptsPermissions.Branches.Default, L("Permission:Branches"));
        branchPermission.AddChild(EgyptRecieptsPermissions.Branches.Create, L("Permission:Create"));
        branchPermission.AddChild(EgyptRecieptsPermissions.Branches.Edit, L("Permission:Edit"));
        branchPermission.AddChild(EgyptRecieptsPermissions.Branches.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EgyptRecieptsResource>(name);
    }
}