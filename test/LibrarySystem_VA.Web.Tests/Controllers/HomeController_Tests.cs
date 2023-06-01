using System.Threading.Tasks;
using LibrarySystem_VA.Models.TokenAuth;
using LibrarySystem_VA.Web.Controllers;
using Shouldly;
using Xunit;

namespace LibrarySystem_VA.Web.Tests.Controllers
{
    public class HomeController_Tests: LibrarySystem_VAWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}