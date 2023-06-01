using System.Collections.Generic;
using System.Linq;
using LibrarySystem_VA.Roles.Dto;
using LibrarySystem_VA.Users.Dto;

namespace LibrarySystem_VA.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
