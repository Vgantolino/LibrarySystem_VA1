using System.Collections.Generic;
using LibrarySystem_VA.Roles.Dto;

namespace LibrarySystem_VA.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}