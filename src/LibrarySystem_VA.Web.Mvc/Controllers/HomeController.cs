using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LibrarySystem_VA.Controllers;

namespace LibrarySystem_VA.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LibrarySystem_VAControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
