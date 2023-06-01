using Abp.AspNetCore.Mvc.ViewComponents;

namespace LibrarySystem_VA.Web.Views
{
    public abstract class LibrarySystem_VAViewComponent : AbpViewComponent
    {
        protected LibrarySystem_VAViewComponent()
        {
            LocalizationSourceName = LibrarySystem_VAConsts.LocalizationSourceName;
        }
    }
}
