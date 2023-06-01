using System.Collections.Generic;
using LibrarySystem_VA.Roles.Dto;

namespace LibrarySystem_VA.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
