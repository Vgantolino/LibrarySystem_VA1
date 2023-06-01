using Abp.Authorization;
using LibrarySystem_VA.Authorization.Roles;
using LibrarySystem_VA.Authorization.Users;

namespace LibrarySystem_VA.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
