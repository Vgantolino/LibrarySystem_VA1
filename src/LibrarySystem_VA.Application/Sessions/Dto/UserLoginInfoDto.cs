using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystem_VA.Authorization.Users;

namespace LibrarySystem_VA.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
