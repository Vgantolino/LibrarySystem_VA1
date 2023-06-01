using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using LibrarySystem_VA.Configuration;
using LibrarySystem_VA.Web;

namespace LibrarySystem_VA.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LibrarySystem_VADbContextFactory : IDesignTimeDbContextFactory<LibrarySystem_VADbContext>
    {
        public LibrarySystem_VADbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LibrarySystem_VADbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            LibrarySystem_VADbContextConfigurer.Configure(builder, configuration.GetConnectionString(LibrarySystem_VAConsts.ConnectionStringName));

            return new LibrarySystem_VADbContext(builder.Options);
        }
    }
}
