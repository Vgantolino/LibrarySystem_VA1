using Abp.AutoMapper;
using LibrarySystem_VA.Roles.Dto;
using LibrarySystem_VA.Web.Models.Common;

namespace LibrarySystem_VA.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
