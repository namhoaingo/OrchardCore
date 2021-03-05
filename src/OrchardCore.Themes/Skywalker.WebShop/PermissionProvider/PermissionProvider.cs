using System.Collections.Generic;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace Skywalker.WebShop.PermissionProvider
{
    public class PermissionProvider : IPermissionProvider
    {
        public static readonly Permission ManageCommerceSettings = new Permission("ManageCommerceSettings", "Manage Commerce Settings");

        public IEnumerable<Permission> GetPermissions()
            => new[] { ManageCommerceSettings };

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
            => Task.FromResult(GetPermissions());
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
            => new[] { new PermissionStereotype {
                Name = "Administrator",
                Permissions = new[] { ManageCommerceSettings }
            } };
    }
}
