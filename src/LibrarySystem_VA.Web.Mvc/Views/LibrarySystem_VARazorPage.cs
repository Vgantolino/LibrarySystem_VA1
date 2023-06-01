using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace LibrarySystem_VA.Web.Views
{
    public abstract class LibrarySystem_VARazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected LibrarySystem_VARazorPage()
        {
            LocalizationSourceName = LibrarySystem_VAConsts.LocalizationSourceName;
        }
    }
}
