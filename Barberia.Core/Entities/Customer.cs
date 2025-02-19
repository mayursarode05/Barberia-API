using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public Guid CustomerTypeId { get; set; }
        public Guid AppUserId { get; set; }
    }
}
