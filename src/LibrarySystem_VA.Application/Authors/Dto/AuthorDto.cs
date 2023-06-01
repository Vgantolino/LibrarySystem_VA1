using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystem_VA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Authors.Dto
{
    [AutoMapFrom(typeof(Author))]
    [AutoMapTo(typeof(Author))]

    public class AuthorDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
