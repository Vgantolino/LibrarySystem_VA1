using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibrarySystem_VA.Configuration;

namespace LibrarySystem_VA.Web.Host.Startup
{
    [DependsOn(
       typeof(LibrarySystem_VAWebCoreModule))]
    public class LibrarySystem_VAWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LibrarySystem_VAWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibrarySystem_VAWebHostModule).GetAssembly());
        }
    }
}
