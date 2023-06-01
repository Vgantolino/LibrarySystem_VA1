using Abp.AutoMapper;
using LibrarySystem_VA.Authentication.External;

namespace LibrarySystem_VA.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
