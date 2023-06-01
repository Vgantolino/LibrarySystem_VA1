using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LibrarySystem_VA.Configuration.Dto;

namespace LibrarySystem_VA.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LibrarySystem_VAAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
