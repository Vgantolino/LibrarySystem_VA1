using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LibrarySystem_VA.Controllers
{
    public abstract class LibrarySystem_VAControllerBase: AbpController
    {
        protected LibrarySystem_VAControllerBase()
        {
            LocalizationSourceName = LibrarySystem_VAConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
