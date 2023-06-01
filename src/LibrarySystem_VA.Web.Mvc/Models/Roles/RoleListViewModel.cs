using System.Collections.Generic;
using LibrarySystem_VA.Roles.Dto;

namespace LibrarySystem_VA.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
