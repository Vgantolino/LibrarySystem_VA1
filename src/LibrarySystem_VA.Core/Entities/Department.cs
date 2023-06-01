using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Entities
{
    public class Department : FullAuditedEntity<int>
    {
        public string Name { get; set; }

    }
}
