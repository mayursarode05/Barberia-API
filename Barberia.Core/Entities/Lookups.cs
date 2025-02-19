using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Core.Entities
{
    public class Lookups : BaseEntity
    {
        public string LookupGroupName { get; set; }
        public string LookupName { get; set; }
        public string LookupDisplayName { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
    }
}
