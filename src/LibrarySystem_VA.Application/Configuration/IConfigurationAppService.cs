using System.Threading.Tasks;
using LibrarySystem_VA.Configuration.Dto;

namespace LibrarySystem_VA.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
